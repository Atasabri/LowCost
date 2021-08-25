using AutoMapper;
using LowCost.Business.Helpers;
using LowCost.Business.Services.User.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.User;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
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
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly IMapper _mapper;
        private readonly AuthenticationHandler _authenticationHandler;

        public DashboardDriverService(UserManager<Domain.Models.User> userManager,
            IMapper mapper, AuthenticationHandler authenticationHandler)
        {
            this._userManager = userManager;
            this._mapper = mapper;
            this._authenticationHandler = authenticationHandler;
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
                PhoneNumber = addDriverViewModel.Phone
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
            if (driver != null && await _userManager.IsInRoleAsync(driver, Constants.DriverRoleName))
            {
                return await _userManager.DeleteAsync(driver);
            }
            return new IdentityResult();
        }

        public async Task<IEnumerable<DriverViewModel>> GetAllDriversAsync()
        {
            var drivers = await _userManager.GetUsersInRoleAsync(Constants.DriverRoleName);

            var driversDTOs = _mapper.Map<IEnumerable<Domain.Models.User>, IEnumerable<DriverViewModel>>(drivers);

            return driversDTOs;
        }

        public async Task<PagedResult<DriverViewModel>> GetDriversAsync(PagingParameters pagingParameters)
        {
            int skip = pagingParameters.Index * pagingParameters.Size;
            var drivers = (await _userManager.GetUsersInRoleAsync(Constants.DriverRoleName)).Skip(skip).Take(pagingParameters.Size);

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
