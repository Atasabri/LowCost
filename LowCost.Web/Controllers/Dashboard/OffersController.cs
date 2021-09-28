using LowCost.Business.Services.Offers.Interfaces.Dashboard;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DashboardViewModels.Offers;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    public class OffersController : DashboardController
    {
        private readonly IDashboardOffersService _dashboardOffersService;

        public OffersController(IDashboardOffersService dashboardOffersService)
        {
            this._dashboardOffersService = dashboardOffersService;
        }
        // GET: Offers
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardOffersService.GetDashboardOffersAsync(pagingParameters);
            return View(result);
        }

        // GET: Offers/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardOffersService.GetOfferDetailsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // GET: Offers/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Offers/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddOfferViewModel addOfferViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardOffersService.CreateOfferAsync(addOfferViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            return View(addOfferViewModel);
        }

        // GET: Offers/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardOffersService.GetOfferDetailsAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Offers/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditOfferViewModel editOfferViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardOffersService.EditOfferAsync(editOfferViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var offerViewModel = await _dashboardOffersService.GetOfferDetailsAsync(editOfferViewModel.Id);
            return View(offerViewModel);
        }


        // POST: Offers/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _dashboardOffersService.DeleteOfferAsync(id);
            if (result.ExcuteSuccessfully)
            {
                return Json(id);
            }
            return Json(result.ErrorMessages.FirstOrDefault());
        }
    }
}
