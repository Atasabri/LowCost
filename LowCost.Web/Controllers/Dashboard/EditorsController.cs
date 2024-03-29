﻿using LowCost.Business.Services.Stocks.Interfaces.Dashboard;
using LowCost.Business.Services.User.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.Identity;
using LowCost.Infrastructure.DashboardViewModels.Stocks;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    [Authorize(Roles = Admin.AdminRoleName)]
    public class EditorsController : Controller
    {
        private readonly IDashboardAdminService _dashboardAdminService;
        private readonly IDashboardStocksService _dashboardStocksService;

        public EditorsController(IDashboardAdminService dashboardUserService, IDashboardStocksService dashboardStocksService)
        {
            this._dashboardAdminService = dashboardUserService;
            this._dashboardStocksService = dashboardStocksService;
        }
        public async Task<IActionResult> Index()
        {
            var editors = await _dashboardAdminService.GetEditorsAsync();
            return View(editors);
        }
        public async Task<IActionResult> AddNewEditor()
        {
            ViewBag.Stocks = await _dashboardStocksService.GetAllStocksAsync();
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddNewEditor(AddNewAdminViewModel addNewAdminViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardAdminService.CreateNewEditorAsync(addNewAdminViewModel);
                if (result.Succeeded)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.Errors.FirstOrDefault().Description);
            }
            ViewBag.Stocks = await _dashboardStocksService.GetAllStocksAsync();
            return View(addNewAdminViewModel);
        }
    }
}
