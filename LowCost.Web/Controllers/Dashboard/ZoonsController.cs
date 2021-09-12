using LowCost.Business.Services.Stocks.Interfaces.Dashboard;
using LowCost.Business.Services.Zoons.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.Zoons;
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
    public class ZoonsController : Controller
    {
        private readonly IDashboardZoonsService _dashboardZoonsService;
        private readonly IDashboardStocksService _dashboardStocksService;

        public ZoonsController(IDashboardZoonsService dashboardZoonsService, IDashboardStocksService dashboardStocksService)
        {
            this._dashboardZoonsService = dashboardZoonsService;
            this._dashboardStocksService = dashboardStocksService;
        }
        // GET: Zoons
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardZoonsService.GetDashboardZoonsAsync(pagingParameters);
            return View(result);
        }

        // GET: Zoons/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardZoonsService.GetZoonDetailsAsync(id);
            return View(result);
        }

        // GET: Zoons/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Stocks = await _dashboardStocksService.GetAllStocksAsync();
            return View();
        }

        // POST: Zoons/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddZoonViewModel addZoonViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardZoonsService.CreateZoonAsync(addZoonViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            ViewBag.Stocks = await _dashboardStocksService.GetAllStocksAsync();
            return View(addZoonViewModel);
        }

        // GET: Zoons/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardZoonsService.GetZoonDetailsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            ViewBag.Stocks = await _dashboardStocksService.GetAllStocksAsync();
            return View(result);
        }

        // POST: Zoons/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditZoonViewModel editZoonViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardZoonsService.EditZoonAsync(editZoonViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var zoonViewModel = await _dashboardZoonsService.GetZoonDetailsAsync(editZoonViewModel.Id);
            ViewBag.Stocks = await _dashboardStocksService.GetAllStocksAsync();
            return View(zoonViewModel);
        }


        // POST: Zoons/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _dashboardZoonsService.DeleteZoonAsync(id);
            if (result.ExcuteSuccessfully)
            {
                return Json(id);
            }
            return Json(result.ErrorMessages.FirstOrDefault());
        }
    }
}
