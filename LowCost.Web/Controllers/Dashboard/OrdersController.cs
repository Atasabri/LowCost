using LowCost.Business.Services.Orders.Interfaces.Dashboard;
using LowCost.Business.Services.Search.Interfaces.Dashboard;
using LowCost.Business.Services.User.Interfaces.Dashboard;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DashboardViewModels.Orders;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    public class OrdersController : DashboardController
    {
        private readonly IDashboardOrdersService _dashboardOrdersService;
        private readonly IDashboardDriverService _dashboardDriverService;
        private readonly IDashboardSearchService _dashboardSearchService;

        public OrdersController(IDashboardOrdersService dashboardOrdersService,
            IDashboardDriverService dashboardDriverService, 
            IDashboardSearchService dashboardSearchService)
        {
            this._dashboardOrdersService = dashboardOrdersService;
            this._dashboardDriverService = dashboardDriverService;
            this._dashboardSearchService = dashboardSearchService;
        }

        // GET: Orders
        public async Task<ActionResult> Index(PagingParameters pagingParameters, int? id = null)
        {
            PagedResult<ListingOrderViewModel> result;
            if(id.HasValue)
            {
                result = await _dashboardSearchService.SearchOrdersAsync(id.Value, pagingParameters);
            }
            else
            {
                result = await _dashboardOrdersService.GetOrdersAsync(pagingParameters);
            }
            return View(result);
        }

        // GET: Orders/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardOrdersService.GetOrderDetailsAsync(id);
            return View(result);
        }

        // GET: Orders/AddStatus/5
        public async Task<ActionResult> AddStatus(int id)
        {
            var statuses = await _dashboardOrdersService.GetOrderStatusesAsync(id);
            ViewBag.Order_Id = id;
            ViewBag.Statuses = await _dashboardOrdersService.GetAllStatusesAsync();
            return View(statuses);
        }

        // POST: Orders/AddStatus
        [HttpPost]
        public async Task<ActionResult> AddStatus(AddOrderStatusViewModel addStatusViewModel)
        {
            if(ModelState.IsValid)
            {
                var result = await _dashboardOrdersService.AddOrderStatusAsync(addStatusViewModel);
                if(result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var statuses = await _dashboardOrdersService.GetOrderStatusesAsync(addStatusViewModel.Order_Id);
            ViewBag.Order_Id = addStatusViewModel.Order_Id;
            ViewBag.Statuses = await _dashboardOrdersService.GetAllStatusesAsync();
            return View(statuses);
        }

        // GET: Orders/AssignDriver/5
        public async Task<ActionResult> AssignDriver(int id)
        {
            var order = await _dashboardOrdersService.GetOrderDetailsAsync(id);
            ViewBag.Drivers = await _dashboardDriverService.GetAllDriversAsync();
            return View(order);
        }

        // POST: Orders/AssignDriver
        [HttpPost]
        public async Task<ActionResult> AssignDriver(AddOrderDriverViewModel addOrderDriverViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardOrdersService.AssignOrderDriverAsync(addOrderDriverViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var order = await _dashboardOrdersService.GetOrderDetailsAsync(addOrderDriverViewModel.Order_Id);
            ViewBag.Drivers = await _dashboardDriverService.GetAllDriversAsync();
            return View(order);
        }

        // POST: Orders/Close/5
        [HttpPost]
        public async Task<ActionResult> Close(int id)
        {
            var result = await _dashboardOrdersService.CloseOrderAsync(id);
            if (result.ExcuteSuccessfully)
            {
                return Json(id);
            }
            return Json(result.ErrorMessages.FirstOrDefault());
        }
    }
}
