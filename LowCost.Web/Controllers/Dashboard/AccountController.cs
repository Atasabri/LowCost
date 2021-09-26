using LowCost.Business.Services.Identity.Interfaces.Dashboard;
using LowCost.Business.Services.User.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.Identity;
using LowCost.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    public class AccountController : Controller
    {
        private readonly IDashboardAuthenticationService _dashboardAuthenticationService;
        private readonly IDashboardAdminService _dashboardUserService;

        public AccountController(IDashboardAuthenticationService dashboardAuthenticationService, IDashboardAdminService dashboardUserService)
        {
            this._dashboardAuthenticationService = dashboardAuthenticationService;
            this._dashboardUserService = dashboardUserService;
        }

        public ActionResult Login()
        {
            return View();
        }
        
        [HttpPost]
        public async Task<ActionResult> Login(AdminLoginViewModel adminLoginViewModel, string ReturnUrl = null)
        {
            if(ModelState.IsValid)
            {
                var result = await _dashboardAuthenticationService.AdminLoginAsync(adminLoginViewModel);
                if(result.Succeeded)
                {
                    if (!string.IsNullOrEmpty(ReturnUrl) && Url.IsLocalUrl(ReturnUrl))
                    {
                        return Redirect(ReturnUrl);
                    }
                    return RedirectToAction("Index", "MainCategories");
                }
                ModelState.AddModelError(string.Empty, "InValid Login !!");
            }
            return View(adminLoginViewModel);
        }


        [Authorize(Roles =  Admin.AdminRoleName+ "," +Admin.EditorRoleName)]
        public IActionResult ChangePassword()
        {
            return View();
        }

        [Authorize(Roles = Admin.AdminRoleName + "," + Admin.EditorRoleName)]
        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel changePasswordViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardUserService.ChangePasswordAsync(changePasswordViewModel);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(LogOut));
                }
                ModelState.AddModelError("", result.Errors.FirstOrDefault().Description);
            }
            return View();
        }

        public async Task<ActionResult> LogOut()
        {
            await _dashboardAuthenticationService.AdminLogOutAsync();
            return RedirectToAction(nameof(Login));
        }
    }
}
