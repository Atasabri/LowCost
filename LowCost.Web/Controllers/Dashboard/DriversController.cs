using LowCost.Business.Services.Stocks.Interfaces.Dashboard;
using LowCost.Business.Services.User.Interfaces.Dashboard;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DashboardViewModels.User;
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
    public class DriversController : DashboardController
    {
        private readonly IDashboardStocksService _dashboardStocksService;
        private readonly IDashboardDriverService _dashboardDriverService;

        public DriversController(IDashboardStocksService dashboardStocksService, IDashboardDriverService dashboardDriverService)
        {
            this._dashboardStocksService = dashboardStocksService;
            this._dashboardDriverService = dashboardDriverService;
        }
        public async Task<IActionResult> Index(PagingParameters pagingparameters)
        {
            var drivers = await _dashboardDriverService.GetDriversAsync(pagingparameters);
            return View(drivers);
        }

        public async Task<IActionResult> Create()
        {
            ViewBag.Stocks = await _dashboardStocksService.GetAllStocksAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(AddDriverViewModel addDriverViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardDriverService.CreateDriverAsync(addDriverViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            ViewBag.Stocks = await _dashboardStocksService.GetAllStocksAsync();
            return View(addDriverViewModel);
        }

        [HttpPost]
        public async Task<JsonResult> Delete(string Id)
        {
            var result = await _dashboardDriverService.DeleteDriverAsync(Id);
            if (result.Succeeded)
            {
                return Json(Id);
            }
            return Json(0);
        }
    }
}
