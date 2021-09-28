using LowCost.Business.Services.Stocks.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.Stocks;
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
    public class StocksController : Controller
    {
        private readonly IDashboardStocksService _dashboardStocksService;

        public StocksController(IDashboardStocksService dashboardStocksService)
        {
            this._dashboardStocksService = dashboardStocksService;
        }
        // GET: Stocks
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardStocksService.GetDashboardStocksAsync(pagingParameters);
            return View(result);
        }

        // GET: Stocks/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardStocksService.GetStockDetailsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // GET: Stocks/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Stocks/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddStockViewModel addStockViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardStocksService.CreateStockAsync(addStockViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            return View(addStockViewModel);
        }

        // GET: Stocks/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardStocksService.GetStockDetailsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Stocks/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditStockViewModel editStockViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardStocksService.EditStockAsync(editStockViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var stockViewModel = await _dashboardStocksService.GetStockDetailsAsync(editStockViewModel.Id);
            return View(stockViewModel);
        }


        // POST: Stocks/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _dashboardStocksService.DeleteStockAsync(id);
            if (result.ExcuteSuccessfully)
            {
                return Json(id);
            }
            return Json(result.ErrorMessages.FirstOrDefault());
        }
    }
}
