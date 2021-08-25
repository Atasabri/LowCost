using LowCost.Business.Services.Statuses.Interfaces.Dashboard;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DashboardViewModels.Statuses;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    public class StatusesController : DashboardController
    {
        private readonly IDashboardStatusesService _dashboardStatusesService;

        public StatusesController(IDashboardStatusesService dashboardStatusesService)
        {
            this._dashboardStatusesService = dashboardStatusesService;
        }
        // GET: Statuses
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardStatusesService.GetDashboardStatusesAsync(pagingParameters);
            return View(result);
        }

        // GET: Statuses/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardStatusesService.GetStatusDetailsAsync(id);
            return View(result);
        }

        // GET: Statuses/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Statuses/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddStatusViewModel addStatusViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardStatusesService.CreateStatusAsync(addStatusViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            return View(addStatusViewModel);
        }

        // GET: Statuses/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardStatusesService.GetStatusDetailsAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Statuses/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditStatusViewModel editStatusViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardStatusesService.EditStatusAsync(editStatusViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var statusViewModel = await _dashboardStatusesService.GetStatusDetailsAsync(editStatusViewModel.Id);
            return View(statusViewModel);
        }


        // POST: Statuses/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardStatusesService.DeleteStatusAsync(id);
                if (result.ExcuteSuccessfully)
                {
                    return Json(id);
                }
                return Json(result.ErrorMessages.FirstOrDefault());
            }
            return Json(0);
        }
    }
}
