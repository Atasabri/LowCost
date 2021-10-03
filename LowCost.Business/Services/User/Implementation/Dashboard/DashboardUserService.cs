using AutoMapper;
using LowCost.Business.Services.User.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.User.DashboardUsersViewModels;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
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
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;

        public DashboardUserService(UserManager<Domain.Models.User> userManager, RoleManager<IdentityRole> roleManager, IMapper mapper)
        {
            this._userManager = userManager;
            this._roleManager = roleManager;
            this._mapper = mapper;
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

            var usersViewModel = _mapper.Map<IEnumerable<Domain.Models.User>, IEnumerable<ListingUserViewModel>>(users);

            return new PagedResult<ListingUserViewModel>(pagingParameters.Index, pagingParameters.Size, allUsersCount, usersViewModel);
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
