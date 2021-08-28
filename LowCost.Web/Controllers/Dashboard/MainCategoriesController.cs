using LowCost.Business.Services.Categories.Interfaces.Dashboard;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DashboardViewModels.Categories.MainCategories;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    public class MainCategoriesController : DashboardController
    {
        private readonly IDashboardMainCategoriesService _dashboardMainCategoriesService;

        public MainCategoriesController(IDashboardMainCategoriesService dashboardMainCategoriesService)
        {
            this._dashboardMainCategoriesService = dashboardMainCategoriesService;
        }
        // GET: MainCategories
        public async Task<ActionResult> Index(PagingParameters pagingParameters)
        {
            var result = await _dashboardMainCategoriesService.GetDashboardMainCategoriesAsync(pagingParameters);
            return View(result);
        }

        // GET: MainCategories/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardMainCategoriesService.GetMainCategoryDetailsAsync(id);
            return View(result);
        }

        // GET: MainCategories/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: MainCategories/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddMainCategoryViewModel addmainCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardMainCategoriesService.CreateMainCategoryAsync(addmainCategoryViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            return View(addmainCategoryViewModel);
        }

        // GET: MainCategories/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardMainCategoriesService.GetMainCategoryDetailsAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            return View(result);
        }

        // POST: MainCategories/Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditMainCategoryViewModel editMainCategoryViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardMainCategoriesService.EditMainCategoryAsync(editMainCategoryViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var mainCategoryViewModel = await _dashboardMainCategoriesService.GetMainCategoryDetailsAsync(editMainCategoryViewModel.Id);
            return View(mainCategoryViewModel);
        }


        // POST: MainCategories/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            var result = await _dashboardMainCategoriesService.DeleteMainCategoryAsync(id);
            if (result.ExcuteSuccessfully)
            {
                return Json(id);
            }
            return Json(result.ErrorMessages.FirstOrDefault());
        }
    }
}
