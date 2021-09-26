using LowCost.Business.Services.User.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.User.DashboardUsersViewModels;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    [Authorize(Roles = Admin.AdminRoleName)]
    public class UsersController : Controller
    {
        private readonly IDashboardUserService _dashboardUserService;

        public UsersController(IDashboardUserService dashboardUserService)
        {
            this._dashboardUserService = dashboardUserService;
        }

        public async Task<IActionResult> Index(PagingParameters paginparameters, string searchTerms = null)
        {
            PagedResult<ListingUserViewModel> result;
            if(string.IsNullOrEmpty(searchTerms))
            {
                result = await _dashboardUserService.GetUsersAsync(paginparameters);
            }
            else
            {
                result = await _dashboardUserService.SearchUsersAsync(searchTerms, paginparameters);
            }
            return View(result);
        }

        public async Task<IActionResult> Details(string id)
        {
            var result = await _dashboardUserService.GetUserDetailsAsync(id);
            return View(result);
        }

        public async Task<IActionResult> EditBalance(string id)
        {
            var result = await _dashboardUserService.GetUserBalanceDetailsAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> EditBalance(EditBalanceViewModel editBalanceViewModel)
        {
            var result = await _dashboardUserService.EditUserBalanceAsync(editBalanceViewModel);
            if(result.ExcuteSuccessfully)
            {
                return RedirectToAction(nameof(Details), new { id = editBalanceViewModel.UserId });
            }
            ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            return View(editBalanceViewModel);
        }
    }
}
