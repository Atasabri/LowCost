using LowCost.Business.Services.User.Interfaces.Dashboard;
using LowCost.Business.Services.Wallet.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.User.DashboardUsersViewModels;
using LowCost.Infrastructure.DashboardViewModels.Wallet;
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
        private readonly IDashboardWalletTransactionsService _dashboardWalletTransactionsService;

        public UsersController(IDashboardUserService dashboardUserService, IDashboardWalletTransactionsService dashboardWalletTransactionsService)
        {
            this._dashboardUserService = dashboardUserService;
            this._dashboardWalletTransactionsService = dashboardWalletTransactionsService;
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
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        public async Task<IActionResult> AddDepositTransaction(string id)
        {
            var result = await _dashboardUserService.GetUserBalanceDetailsAsync(id);
            return View(result);
        }

        [HttpPost]
        public async Task<IActionResult> AddDepositTransaction(AddTransactionViewModel addTransactionViewModel)
        {
            var result = await _dashboardWalletTransactionsService.AddDepositTransactionAsync(addTransactionViewModel);
            if(result.CreatedSuccessfully)
            {
                return RedirectToAction(nameof(Details), new { id = addTransactionViewModel.UserId});
            }
            ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            return RedirectToAction(nameof(AddDepositTransaction), new { id = addTransactionViewModel.UserId });
        }
    }
}
