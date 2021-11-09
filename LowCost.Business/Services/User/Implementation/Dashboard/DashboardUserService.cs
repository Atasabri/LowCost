using AutoMapper;
using LowCost.Business.Services.User.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Orders;
using LowCost.Infrastructure.DashboardViewModels.User.DashboardUsersViewModels;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.NotificationsHelpers.MobileNotificationModels;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.User.Implementation.Dashboard
{
    public class DashboardUserService : IDashboardUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        readonly Action<IMappingOperationOptions<IEnumerable<Domain.Models.User>, IEnumerable<ListingUserViewModel>>> opts = null;


        public DashboardUserService(IUnitOfWork unitOfWork, UserManager<Domain.Models.User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._mapper = mapper;

            opts = opts => opts.AfterMap((src, dest) => {
                foreach (var item in dest)
                {
                    item.OrdersCount = _unitOfWork.OrdersRepository.GetCountAsync(order => order.User_Id == item.Id).Result;
                    item.OrdersTotal = _unitOfWork.OrdersRepository.GetOrdersTotalSumAsync(order => order.User_Id == item.Id).Result;
                }
            });

        }

        public async Task<UserBalanceDetailsViewModel> GetUserBalanceDetailsAsync(string id)
        {
            var user = await _userManager.FindByIdAsync(id);

            var userBalanceDetailsViewModel = _mapper.Map<Domain.Models.User, UserBalanceDetailsViewModel>(user);
            
            return userBalanceDetailsViewModel;
        }

        public async Task<UserViewModel> GetUserDetailsAsync(string id)
        {
            var user = await _userManager.Users
                .Include(nameof(Domain.Models.User.Addresses))
                .Include(nameof(Domain.Models.User.WalletTransactions))
                .Include(nameof(Domain.Models.User.Addresses))
                .Include(nameof(Domain.Models.User.Zone))
                .FirstOrDefaultAsync(user => user.Id == id);

            // Check if User in Group Users
            if(!(await _userManager.IsInRoleAsync(user, Constants.UserRoleName)))
            {
                return null;
            }
            // Mapping and Add Login Provider
            var logins = await _userManager.GetLoginsAsync(user);
            var userViewModel = _mapper.Map<Domain.Models.User, UserViewModel>(user);
            userViewModel.LoginProvider = string.Join(",", logins.Select(login => login.LoginProvider).ToArray());

            // Adding User Orders
            var userOrders = await _unitOfWork.OrdersRepository.GetElementsAsync(order => order.User_Id == user.Id);
            userViewModel.Orders = _mapper.Map<IEnumerable<Order>, IEnumerable<ListingOrderViewModel>>(userOrders).ToList();
            
            return userViewModel;
        }

        public async Task<PagedResult<ListingUserViewModel>> GetUsersAsync(PagingParameters pagingParameters)
        {
            // Get User Role
            var role = await _roleManager.FindByNameAsync(Constants.UserRoleName);
            // Get All Users Count
            var allUsersCount = await _userManager.Users.Include(nameof(Domain.Models.User.UserRoles)).Where(user => user.UserRoles.Any(userRole => userRole.RoleId == role.Id)).CountAsync();
            // Get All User in Group Users
            var users = await _userManager.Users.Include(nameof(Domain.Models.User.UserRoles)).Where(user => user.UserRoles.Any(userRole => userRole.RoleId == role.Id))
                .Skip(pagingParameters.Index * pagingParameters.Size).Take(pagingParameters.Size).ToListAsync();

            var usersViewModel = _mapper.Map<IEnumerable<Domain.Models.User>, IEnumerable<ListingUserViewModel>>(users, opts);

            return new PagedResult<ListingUserViewModel>(pagingParameters.Index, pagingParameters.Size, allUsersCount, usersViewModel);
        }
        
        public async Task<List<string>> NotifyUsersAsync(NotifyUsersViewModel notifyUsersViewModel)
        {
            var role = await _roleManager.FindByNameAsync(Constants.UserRoleName);
            var result = new List<string>();

            if(notifyUsersViewModel.AllUsers)
            {
                int index = notifyUsersViewModel.Paging.Index;
                int size = notifyUsersViewModel.Paging.Size;
                var users = await _userManager.Users.Include(nameof(Domain.Models.User.UserRoles)).Where(user => user.UserRoles.Any(userRole => userRole.RoleId == role.Id)).Skip(index * size).Take(size).ToListAsync();

                foreach (var user in users)
                {
                    string title = (user.CurrentLangauge == Languages.EN) ? notifyUsersViewModel.Header : notifyUsersViewModel.Header_AR;
                    string body = (user.CurrentLangauge == Languages.EN) ? notifyUsersViewModel.Message : notifyUsersViewModel.Message_AR;
                    var topicNotifyState = new TopicNotifyState()
                    {
                        Topic = user.Id,
                        Title = title,
                        Body = body,
                        NotificationHiddenData = new { }
                    };
                    // Sending Notification To User Device 
                    await _unitOfWork.NotificationsRepository.NotifyTopicAsync(topicNotifyState);

                    // Adding Notification To User
                    await _unitOfWork.NotificationsRepository.CreateAsync(new Notification()
                    {
                        DateTime = DateTimeProvider.GetEgyptDateTime(),
                        Message = body,
                        User_Id = user.Id,
                    });

                    result.Add(user.UserName);
                }
            }
            else
            {
                foreach (var userId in notifyUsersViewModel.SelectedUsers)
                {
                    // Get User Data
                    var user = await _userManager.FindByIdAsync(userId);
                    if(user != null)
                    {

                        string title = (user.CurrentLangauge == Languages.EN) ? notifyUsersViewModel.Header : notifyUsersViewModel.Header_AR;
                        string body = (user.CurrentLangauge == Languages.EN) ? notifyUsersViewModel.Message : notifyUsersViewModel.Message_AR;
                        var topicNotifyState = new TopicNotifyState()
                        {
                            Topic = user.Id,
                            Title = title,
                            Body = body,
                            NotificationHiddenData = new { }
                        };
                        // Sending Notification To User Device 
                        await _unitOfWork.NotificationsRepository.NotifyTopicAsync(topicNotifyState);

                        // Adding Notification To User
                        await _unitOfWork.NotificationsRepository.CreateAsync(new Notification()
                        {
                            DateTime = DateTimeProvider.GetEgyptDateTime(),
                            Message = body,
                            User_Id = user.Id
                        });

                        result.Add(user.UserName);
                    }
                }
            }

            await _unitOfWork.SaveAsync();
            return result;
        }

        public async Task<PagedResult<ListingUserViewModel>> SearchUsersAsync(string searchTerms, PagingParameters pagingParameters)
        {
            // Get User Role
            var role = await _roleManager.FindByNameAsync(Constants.UserRoleName);
            // Get All Users Count
            var allUsersCount = await _userManager.Users.Include(nameof(Domain.Models.User.UserRoles)).Where(user => user.UserRoles.Any(userRole => userRole.RoleId == role.Id)
                                && (user.UserName.Contains(searchTerms)
                                || user.FullName.Contains(searchTerms)
                                || user.Email.Contains(searchTerms)
                                || user.PhoneNumber.Contains(searchTerms))).CountAsync();
            // Get All User in Group Users
            var users = await _userManager.Users.Include(nameof(Domain.Models.User.UserRoles)).Where(user => user.UserRoles.Any(userRole => userRole.RoleId == role.Id)
                                && (user.UserName.Contains(searchTerms)
                                || user.FullName.Contains(searchTerms)
                                || user.Email.Contains(searchTerms)
                                || user.PhoneNumber.Contains(searchTerms)))
                .Skip(pagingParameters.Index * pagingParameters.Size).Take(pagingParameters.Size).ToListAsync();

            var usersViewModel = _mapper.Map<IEnumerable<Domain.Models.User>, IEnumerable<ListingUserViewModel>>(users);

            return new PagedResult<ListingUserViewModel>(pagingParameters.Index, pagingParameters.Size, allUsersCount, usersViewModel);
        }
    }
}
