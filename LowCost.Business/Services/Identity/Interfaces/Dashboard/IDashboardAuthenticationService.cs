using LowCost.Infrastructure.DashboardViewModels.Identity;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Identity.Interfaces.Dashboard
{
    public interface IDashboardAuthenticationService
    {
        /// <summary>
        /// Login To Dashboard As Admin Using User Name & Password Asynchronous
        /// </summary>
        /// <param name="adminLoginViewModel"></param>
        /// <returns></returns>
        Task<SignInResult> AdminLoginAsync(AdminLoginViewModel adminLoginViewModel);
        /// <summary>
        /// Log Out From Dshboard Asynchronous
        /// </summary>
        /// <returns></returns>
        Task AdminLogOutAsync();
    }
}
