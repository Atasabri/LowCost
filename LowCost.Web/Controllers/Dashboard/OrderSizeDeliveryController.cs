using LowCost.Business.Services.OrderSizeDelivery.Interfaces.Dashboard;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DashboardViewModels.OrderSizeDelivery;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    [Authorize(Roles = Admin.AdminRoleName)]
    public class OrderSizeDeliveryController : Controller
    {
        private readonly IDashboardOrderSizeDeliveryService _dashboardOrderSizeDeliverysService;

        public OrderSizeDeliveryController(IDashboardOrderSizeDeliveryService dashboardOrderSizeDeliverysService)
        {
            this._dashboardOrderSizeDeliverysService = dashboardOrderSizeDeliverysService;
        }
        // GET: OrderSizeDelivery
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardOrderSizeDeliverysService.GetDashboardOrderSizeDeliverysAsync(pagingParameters);
            return View(result);
        }

        // GET: OrderSizeDelivery/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardOrderSizeDeliverysService.GetOrderSizeDeliveryDetailsAsync(id);
            return View(result);
        }

        // GET: OrderSizeDelivery/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderSizeDelivery/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddOrderSizeDeliveryViewModel addOrderSizeDeliveryViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardOrderSizeDeliverysService.CreateOrderSizeDeliveryAsync(addOrderSizeDeliveryViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            return View(addOrderSizeDeliveryViewModel);
        }

        // GET: OrderSizeDelivery/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardOrderSizeDeliverysService.GetOrderSizeDeliveryDetailsAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: OrderSizeDelivery/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditOrderSizeDeliveryViewModel editOrderSizeDeliveryViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardOrderSizeDeliverysService.EditOrderSizeDeliveryAsync(editOrderSizeDeliveryViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var OrderSizeDeliveryViewModel = await _dashboardOrderSizeDeliverysService.GetOrderSizeDeliveryDetailsAsync(editOrderSizeDeliveryViewModel.Id);
            return View(OrderSizeDeliveryViewModel);
        }


        // POST: OrderSizeDelivery/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _dashboardOrderSizeDeliverysService.DeleteOrderSizeDeliveryAsync(id);
            if (result.ExcuteSuccessfully)
            {
                return Json(id);
            }
            return Json(result.ErrorMessages.FirstOrDefault());
        }
    }
}
