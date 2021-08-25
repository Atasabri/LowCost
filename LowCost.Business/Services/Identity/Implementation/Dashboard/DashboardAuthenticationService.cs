using LowCost.Business.Services.Identity.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.Identity;
using LowCost.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;


namespace LowCost.Business.Services.Identity.Implementation.Dashboard
{
    public class DashboardAuthenticationService : IDashboardAuthenticationService
    {
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly SignInManager<Domain.Models.User> _signInManager;

        public DashboardAuthenticationService(UserManager<Domain.Models.User> userManager, SignInManager<Domain.Models.User> signInManager)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
        }
        public async Task<SignInResult> AdminLoginAsync(AdminLoginViewModel adminLoginViewModel)
        {
            var user = await _userManager.FindByNameAsync(adminLoginViewModel.UserName);
            if(await _userManager.IsInRoleAsync(user, Admin.AdminRoleName) || await _userManager.IsInRoleAsync(user, Admin.EditorRoleName))
            {
                return await _signInManager.PasswordSignInAsync(adminLoginViewModel.UserName,
                                                            adminLoginViewModel.Password,
                                                            true,
                                                            false);
            }
            return new SignInResult();
        }

        public async Task AdminLogOutAsync()
        {
            await _signInManager.SignOutAsync();
        }
    }
}
