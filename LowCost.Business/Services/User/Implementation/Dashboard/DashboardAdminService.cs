using AutoMapper;
using LowCost.Business.Services.User.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.Identity;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.User.Implementation.Dashboard
{
    public class DashboardAdminService : IDashboardAdminService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly IMapper _mapper;

        public DashboardAdminService(IUnitOfWork unitOfWork, UserManager<Domain.Models.User> userManager, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
            this._mapper = mapper;
        }

        public async Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel)
        {
            var user = await _unitOfWork.CurrentUserRepository.GetCurrentDashboardAdminUser();
            return await _userManager.ChangePasswordAsync(user,
                                                          changePasswordViewModel.CurrentPassword,
                                                          changePasswordViewModel.NewPassword);
        }

        public async Task<IdentityResult> CreateNewAdminAsync(AddNewAdminViewModel addNewAdminViewModel)
        {
            var user = _mapper.Map<AddNewAdminViewModel, Domain.Models.User>(addNewAdminViewModel);
            // Admin User Can Not Have Stock (Access All Data)
            user.Stock_Id = null;
            var result = await _userManager.CreateAsync(user, addNewAdminViewModel.Password);
            if(result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, Admin.AdminRoleName);
            }
            return result;
        }

        public async Task<IdentityResult> CreateNewEditorAsync(AddNewAdminViewModel addNewAdminViewModel)
        {
            var user = _mapper.Map<AddNewAdminViewModel, Domain.Models.User>(addNewAdminViewModel);
            
            var result = await _userManager.CreateAsync(user, addNewAdminViewModel.Password);
            if (result.Succeeded)
            {
                result = await _userManager.AddToRoleAsync(user, Admin.EditorRoleName);
            }
            return result;
        }

        public async Task<IdentityResult> DeleteAsync(string Id)
        {
            var user = await _userManager.FindByIdAsync(Id);
            var result = new IdentityResult();
            if(user != null)
            {
                if(await _userManager.IsInRoleAsync(user, Admin.AdminRoleName))
                {
                    if ((await _userManager.GetUsersInRoleAsync(Admin.AdminRoleName)).Count > 1)
                    {
                        result = await _userManager.DeleteAsync(user);
                    }
                }
                else
                {
                    result = await _userManager.DeleteAsync(user);
                }

            }
            return result;
        }

        public async Task<IEnumerable<AdminViewModel>> GetAdminsAsync()
        {
            var admins = await _userManager.GetUsersInRoleAsync(Admin.AdminRoleName);

            var adminsDTOs = _mapper.Map <IEnumerable<Domain.Models.User>, IEnumerable <AdminViewModel>>(admins);

            return adminsDTOs;
        }

        public async Task<IEnumerable<AdminViewModel>> GetEditorsAsync()
        {
            var editors = await _userManager.GetUsersInRoleAsync(Admin.EditorRoleName);

            var editorsDTOs = _mapper.Map<IEnumerable<Domain.Models.User>, IEnumerable<AdminViewModel>>(editors);

            return editorsDTOs;
        }
    }
}
