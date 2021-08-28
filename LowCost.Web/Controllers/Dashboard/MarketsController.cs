using LowCost.Business.Services.Markets.Interfaces.Dashboard;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DashboardViewModels.Markets;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    public class MarketsController : DashboardController
    {
        private readonly IDashboardMarketsService _dashboardMarketsService;

        public MarketsController(IDashboardMarketsService dashboardMarketsService)
        {
            this._dashboardMarketsService = dashboardMarketsService;
        }
        // GET: Markets
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardMarketsService.GetDashboardMarketsAsync(pagingParameters);
            return View(result);
        }

        // GET: Markets/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardMarketsService.GetMarketDetailsAsync(id);
            return View(result);
        }

        // GET: Markets/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Markets/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddMarketViewModel addMarketViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardMarketsService.CreateMarketAsync(addMarketViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            return View(addMarketViewModel);
        }

        // GET: Markets/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardMarketsService.GetMarketDetailsAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Markets/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditMarketViewModel editMarketViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardMarketsService.EditMarketAsync(editMarketViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var marketViewModel = await _dashboardMarketsService.GetMarketDetailsAsync(editMarketViewModel.Id);
            return View(marketViewModel);
        }


        // POST: Markets/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _dashboardMarketsService.DeleteMarketAsync(id);
            if (result.ExcuteSuccessfully)
            {
                return Json(id);
            }
            return Json(result.ErrorMessages.FirstOrDefault());
        }
    }
}
