using LowCost.Business.Services.Sliders.Interfaces.Dashboard;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DashboardViewModels.Sliders;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    public class SlidersController : DashboardController
    {
        private readonly IDashboardSlidersService _dashboardSlidersService;

        public SlidersController(IDashboardSlidersService dashboardSlidersService)
        {
            this._dashboardSlidersService = dashboardSlidersService;
        }
        // GET: Sliders
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardSlidersService.GetDashboardSlidersAsync(pagingParameters);
            return View(result);
        }

        // GET: Sliders/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardSlidersService.GetSliderDetailsAsync(id);
            return View(result);
        }

        // GET: Sliders/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Sliders/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddSliderViewModel addSliderViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardSlidersService.CreateSliderAsync(addSliderViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            return View(addSliderViewModel);
        }

        // GET: Sliders/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardSlidersService.GetSliderDetailsAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: Sliders/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditSliderViewModel editSliderViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardSlidersService.EditSliderAsync(editSliderViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var sliderViewModel = await _dashboardSlidersService.GetSliderDetailsAsync(editSliderViewModel.Id);
            return View(sliderViewModel);
        }


        // POST: Sliders/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _dashboardSlidersService.DeleteSliderAsync(id);
            if (result.ExcuteSuccessfully)
            {
                return Json(id);
            }
            return Json(result.ErrorMessages.FirstOrDefault());
        }
    }
}
