using AutoMapper;
using LowCost.Business.Helpers;
using LowCost.Business.Services.User.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.User;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.User.Implementation.Dashboard
{
    public class DashboardDriverService : IDashboardDriverService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly IMapper _mapper;
        private readonly AuthenticationHandler _authenticationHandler;
        Domain.Models.User currentAdmin = null;

        public DashboardDriverService(IUnitOfWork unitOfWork, UserManager<Domain.Models.User> userManager,
            IMapper mapper, AuthenticationHandler authenticationHandler)
        {
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
            this._mapper = mapper;
            this._authenticationHandler = authenticationHandler;
            currentAdmin =  _unitOfWork.UsersRepository.GetCurrentDashboardAdminUser().Result;
        }
        public async Task<ActionState> CreateDriverAsync(AddDriverViewModel addDriverViewModel)
        {
            var actionState = new ActionState();
            var checkPhoneResult = await _authenticationHandler.CheckPhoneNumberAvailableAsync(addDriverViewModel.Phone);
            if (!checkPhoneResult.ExcuteSuccessfully)
            {
                actionState.ErrorMessages.AddRange(checkPhoneResult.ErrorMessages);
                return actionState;
            }
            var driver = new Domain.Models.User()
            {
                FullName = addDriverViewModel.FullName,
                UserName = addDriverViewModel.Email,
                Email = addDriverViewModel.Email,
                PhoneNumber = addDriverViewModel.Phone,
                Stock_Id = currentAdmin.Stock_Id == null ? addDriverViewModel.Stock_Id : currentAdmin.Stock_Id
            };
            var result = await _userManager.CreateAsync(driver, addDriverViewModel.Password);
            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(driver, Constants.DriverRoleName);
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.AddRange(result.Errors.Select(error => error.Description).ToList());
            return actionState;
        }

        public async Task<IdentityResult> DeleteDriverAsync(string Id)
        {
            var driver = await _userManager.FindByIdAsync(Id);
            if(currentAdmin.Stock_Id != null && currentAdmin.Stock_Id != driver.Stock_Id)
            {
                return new IdentityResult();
            }
            if (driver != null && await _userManager.IsInRoleAsync(driver, Constants.DriverRoleName))
            {
                return await _userManager.DeleteAsync(driver);
            }
            return new IdentityResult();
        }

        public async Task<IEnumerable<DriverViewModel>> GetAllDriversAsync()
        {
            var drivers = (await _userManager.GetUsersInRoleAsync(Constants.DriverRoleName)).Where(driver => currentAdmin.Stock_Id == null || currentAdmin.Stock_Id == driver.Stock_Id);

            var driversDTOs = _mapper.Map<IEnumerable<Domain.Models.User>, IEnumerable<DriverViewModel>>(drivers);

            return driversDTOs;
        }

        public async Task<PagedResult<DriverViewModel>> GetDriversAsync(PagingParameters pagingParameters)
        {
            int skip = pagingParameters.Index * pagingParameters.Size;
            var drivers = (await _userManager.GetUsersInRoleAsync(Constants.DriverRoleName)).Where(driver => currentAdmin.Stock_Id == null || currentAdmin.Stock_Id == driver.Stock_Id).Skip(skip).Take(pagingParameters.Size);

            var driversDTOs = _mapper.Map<IEnumerable<Domain.Models.User>, IEnumerable<DriverViewModel>>(drivers);
            var result = new PagedResult<DriverViewModel>()
            {
                PageNumber = pagingParameters.Index + 1,
                Items = driversDTOs,
                Size = pagingParameters.Size,
                AllCount = (await _userManager.GetUsersInRoleAsync(Constants.DriverRoleName)).Count
            };
            return result;
        }
    }
}
