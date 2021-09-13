using LowCost.Business.Services.Stocks.Interfaces.Dashboard;
using LowCost.Business.Services.Zones.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.Zones;
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
    public class ZonesController : Controller
    {
        private readonly IDashboardZonesService _dashboardZonesService;
        private readonly IDashboardStocksService _dashboardStocksService;

        public ZonesController(IDashboardZonesService dashboardZonesService, IDashboardStocksService dashboardStocksService)
        {
            this._dashboardZonesService = dashboardZonesService;
            this._dashboardStocksService = dashboardStocksService;
        }
        // GET: Zones
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardZonesService.GetDashboardZonesAsync(pagingParameters);
            return View(result);
        }

        // GET: Zones/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardZonesService.GetZoneDetailsAsync(id);
            return View(result);
        }

        // GET: Zones/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.Stocks = await _dashboardStocksService.GetAllStocksAsync();
            return View();
        }

        // POST: Zones/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddZoneViewModel addZoneViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardZonesService.CreateZoneAsync(addZoneViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            ViewBag.Stocks = await _dashboardStocksService.GetAllStocksAsync();
            return View(addZoneViewModel);
        }

        // GET: Zones/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardZonesService.GetZoneDetailsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            ViewBag.Stocks = await _dashboardStocksService.GetAllStocksAsync();
            return View(result);
        }

        // POST: Zones/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditZoneViewModel editZoneViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardZonesService.EditZoneAsync(editZoneViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var zoneViewModel = await _dashboardZonesService.GetZoneDetailsAsync(editZoneViewModel.Id);
            ViewBag.Stocks = await _dashboardStocksService.GetAllStocksAsync();
            return View(zoneViewModel);
        }


        // POST: Zones/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _dashboardZonesService.DeleteZoneAsync(id);
            if (result.ExcuteSuccessfully)
            {
                return Json(id);
            }
            return Json(result.ErrorMessages.FirstOrDefault());
        }
    }
}
