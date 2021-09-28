using LowCost.Business.Services.Categories.Interfaces.Dashboard;
using LowCost.Business.Services.PromoCodes.Interfaces.Dashboard;
using LowCost.Business.Services.Zones.Interfaces.Dashboard;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DashboardViewModels.PromoCodes;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    public class PromoCodesController : DashboardController
    {
        private readonly IDashboardMainCategoriesService _dashboardMainCategoriesService;
        private readonly IDashboardSubCategoriesService _dashboardSubCategoriesService;
        private readonly IDashboardCategoriesService _dashboardCategoriesService;
        private readonly IDashboardZonesService _dashboardZonesService;
        private readonly IDashboardPromoCodeService _dashboardPromoCodeService;

        public PromoCodesController(IDashboardMainCategoriesService dashboardMainCategoriesService,
            IDashboardSubCategoriesService dashboardSubCategoriesService,
            IDashboardCategoriesService dashboardCategoriesService, 
            IDashboardZonesService dashboardZonesService, 
            IDashboardPromoCodeService dashboardPromoCodeService)
        {
            this._dashboardMainCategoriesService = dashboardMainCategoriesService;
            this._dashboardSubCategoriesService = dashboardSubCategoriesService;
            this._dashboardCategoriesService = dashboardCategoriesService;
            this._dashboardZonesService = dashboardZonesService;
            this._dashboardPromoCodeService = dashboardPromoCodeService;
        }
        // GET: PromoCodes
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardPromoCodeService.GetDashboardPromoCodesAsync(pagingParameters);
            return View(result);
        }

        // GET: PromoCodes/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardPromoCodeService.GetPromoCodeDetailsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // GET: PromoCodes/Create
        public async Task<ActionResult> Create()
        {
            await ConfigureViewData();
            return View();
        }

        // POST: PromoCodes/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddPromoCodeViewModel addPromoCodeViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardPromoCodeService.CreatePromoCodeAsync(addPromoCodeViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            await ConfigureViewData();
            return View(addPromoCodeViewModel);
        }

        // GET: PromoCodes/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardPromoCodeService.GetPromoCodeDetailsAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            await ConfigureViewData();
            return View(result);
        }

        // POST: PromoCodes/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditPromoCodeViewModel editPromoCodeViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardPromoCodeService.EditPromoCodeAsync(editPromoCodeViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var promoCodeViewModel = await _dashboardPromoCodeService.GetPromoCodeDetailsAsync(editPromoCodeViewModel.Id);
            await ConfigureViewData();
            return View(promoCodeViewModel);
        }

        private async Task ConfigureViewData()
        {
            ViewBag.Zones = await _dashboardZonesService.GetDashboardAllZonesAsync();
            ViewBag.MainCategories = await _dashboardMainCategoriesService.GetAllMainCategoriesAsync();
        }
        // POST: PromoCodes/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _dashboardPromoCodeService.DeletePromoCodeAsync(id);
            if (result.ExcuteSuccessfully)
            {
                return Json(id);
            }
            return Json(result.ErrorMessages.FirstOrDefault());
        }
    }
}
