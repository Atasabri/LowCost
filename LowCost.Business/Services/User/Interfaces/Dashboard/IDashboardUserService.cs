using LowCost.Infrastructure.DashboardViewModels.Identity;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.User.Interfaces.Dashboard
{
    public interface IDashboardUserService
    {
        /// <summary>
        /// Adding New User With Role Admin Asynchronous
        /// </summary>
        /// <param name="addNewAdminViewModel"></param>
        /// <returns></returns>
        Task<IdentityResult> CreateNewAdminAsync(AddNewAdminViewModel addNewAdminViewModel);
        /// <summary>
        /// Get Listing Admins Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AdminViewModel>> GetAdminsAsync();
        /// <summary>
        /// Adding New User With Role Editor Asynchronous
        /// </summary>
        /// <param name="addNewAdminViewModel"></param>
        /// <returns></returns>
        Task<IdentityResult> CreateNewEditorAsync(AddNewAdminViewModel addNewAdminViewModel);
        /// <summary>
        /// Get Listing Editors Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<AdminViewModel>> GetEditorsAsync();
        /// <summary>
        /// Change Admin Or Editor Password Asynchronous
        /// </summary>
        /// <param name="changePasswordViewModel"></param>
        /// <returns></returns>
        Task<IdentityResult> ChangePasswordAsync(ChangePasswordViewModel changePasswordViewModel);
        /// <summary>
        /// Delete Admin Or Editor Using Id Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<IdentityResult> DeleteAsync(string Id);
    }
}
