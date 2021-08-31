using LowCost.Business.Services.Categories.Interfaces.Dashboard;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DashboardViewModels.Categories.Categories;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    public class CategoriesController : DashboardController
    {
        private readonly IDashboardCategoriesService _dashboardCategoriesService;
        private readonly IDashboardMainCategoriesService _dashboardMainCategoriesService;

        public CategoriesController(IDashboardCategoriesService dashboardCategoriesService,
            IDashboardMainCategoriesService dashboardMainCategoriesService)
        {
            this._dashboardCategoriesService = dashboardCategoriesService;
            this._dashboardMainCategoriesService = dashboardMainCategoriesService;
        }
        // GET: Categories
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardCategoriesService.GetDashboardCategoriesAsync(pagingParameters);
            return View(result);
        }

        // GET: Categories/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardCategoriesService.GetCategoryDetailsAsync(id);
            return View(result);
        }

        // GET: Categories/Create
        public async Task<ActionResult> Create()
        {
            ViewBag.MainCategories = await _dashboardMainCategoriesService.GetAllMainCategoriesAsync();
            return View();
        }

        // POST: Categories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddCategoryViewModel addCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardCategoriesService.CreateCategoryAsync(addCategoryViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }

            ViewBag.MainCategories = await _dashboardMainCategoriesService.GetAllMainCategoriesAsync();
            return View(addCategoryViewModel);
        }

        // GET: Categories/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardCategoriesService.GetCategoryDetailsAsync(id);
            if(result == null)
            {
                return NotFound();
            }

            ViewBag.MainCategories = await _dashboardMainCategoriesService.GetAllMainCategoriesAsync();
            return View(result);
        }

        // POST: Categories/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditCategoryViewModel editCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardCategoriesService.EditCategoryAsync(editCategoryViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var categoryViewModel = await _dashboardCategoriesService.GetCategoryDetailsAsync(editCategoryViewModel.Id);
            ViewBag.MainCategories = await _dashboardMainCategoriesService.GetAllMainCategoriesAsync();
            return View(categoryViewModel);
        }


        // POST: Categories/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _dashboardCategoriesService.DeleteCategoryAsync(id);
            if (result.ExcuteSuccessfully)
            {
                return Json(id);
            }
            return Json(result.ErrorMessages.FirstOrDefault());
        }

        // GET: Categories?mainCatId=1
        public async Task<ActionResult> CategoriesUsingMainCatId(int mainCatId)
        {
            var result = await _dashboardCategoriesService.GetAllCategoriesUsingMainCategoryIdAsync(mainCatId);
            return Json(result);
        }

        // POST/Categories/Order
        [HttpPost]
        public async Task<ActionResult> Order(Dictionary<int, int> orderListItems)
        {
            var result = await _dashboardCategoriesService.OrderCategoriesListAsync(orderListItems);
            return Json(result.ExcuteSuccessfully);
        }

        // POST: Categories/ChangeViewInApp
        [HttpPost]
        public async Task<ActionResult> ChangeViewInApp(int id, bool viewInApp)
        {
            var result = await _dashboardCategoriesService.ChangeViewInAppAsync(id, viewInApp);
            if (result.ExcuteSuccessfully)
            {
                return Json(id);
            }
            return Json(result.ErrorMessages.FirstOrDefault());
        }
    }
}
