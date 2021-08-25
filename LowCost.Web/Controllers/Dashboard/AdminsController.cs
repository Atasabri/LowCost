using LowCost.Business.Services.User.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DashboardViewModels.Identity;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    [Authorize(Roles = Admin.AdminRoleName)]
    public class AdminsController : Controller
    {
        private readonly IDashboardUserService _dashboardUserService;

        public AdminsController(IDashboardUserService dashboardUserService)
        {
            this._dashboardUserService = dashboardUserService;
        }
        public async Task<IActionResult> Index()
        {
            var admins = await _dashboardUserService.GetAdminsAsync();
            return View(admins);
        }

        public IActionResult AddNewAdmin()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewAdmin(AddNewAdminViewModel addNewAdminViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _dashboardUserService.CreateNewAdminAsync(addNewAdminViewModel);
                if(result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Errors.FirstOrDefault().Description);
            }
            return View(addNewAdminViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string Id)
        {
            var result = await _dashboardUserService.DeleteAsync(Id);
            if(result.Succeeded)
            {
                return Json(Id);
            }
            else
            {
                return Json(0);
            }
        }
    }
}
