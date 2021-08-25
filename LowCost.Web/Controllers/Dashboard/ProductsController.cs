using LowCost.Business.Services.Brands.Interfaces.Dashboard;
using LowCost.Business.Services.Categories.Interfaces.Dashboard;
using LowCost.Business.Services.Markets.Interfaces.Dashboard;
using LowCost.Business.Services.Offers.Interfaces.Dashboard;
using LowCost.Business.Services.Products.Interfaces.Dashboard;
using LowCost.Business.Services.Search.Interfaces.Dashboard;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DashboardViewModels.Offers;
using LowCost.Infrastructure.DashboardViewModels.Products;
using LowCost.Infrastructure.DashboardViewModels.Products.Prices;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Dashboard
{
    public class ProductsController : DashboardController
    {
        private readonly IDashboardProductsService _dashboardProductsService;
        private readonly IDashboardOffersService _dashboardOffersService;
        private readonly IDashboardMainCategoriesService _dashboardMainCategoriesService;
        private readonly IDashboardMarketsService _dashboardMarketsService;
        private readonly IDashboardSearchService _dashboardSearchService;
        private readonly IDashboardBrandsService _dashboardBrandsService;


        public ProductsController(IDashboardProductsService dashboardProductsService,
            IDashboardOffersService dashboardOffersService,
            IDashboardMainCategoriesService dashboardMainCategoriesService,
            IDashboardMarketsService dashboardMarketsService,
            IDashboardSearchService dashboardSearchService,
            IDashboardBrandsService dashboardBrandsService)
        {
            this._dashboardProductsService = dashboardProductsService;
            this._dashboardOffersService = dashboardOffersService;
            this._dashboardMainCategoriesService = dashboardMainCategoriesService;
            this._dashboardMarketsService = dashboardMarketsService;
            this._dashboardSearchService = dashboardSearchService;
            this._dashboardBrandsService = dashboardBrandsService;
        }
        // GET: Products
        public async Task<ActionResult> Index(PagingParameters pagingParameters, string searchTerms = null)
        {
            PagedResult<ListingProductViewModel> result;
            if(string.IsNullOrEmpty(searchTerms))
            {
                 result = await _dashboardProductsService.GetDashboardProductsAsync(pagingParameters);
            }
            else
            {
                result = await _dashboardSearchService.SearchProductsAsync(searchTerms, pagingParameters);
            }
            return View(result);
        }

        // GET: Products/Details/5
        public async Task<ActionResult> Details(int id)
        {
            var result = await _dashboardProductsService.GetProductDetailsAsync(id);
            return View(result);
        }

        // GET: Products/Create
        public async Task<ActionResult> Create()
        {
            await ConfigureViewData();
            return View();
        }

        // POST: Products/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(AddProductViewModel addProductViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardProductsService.CreateProductAsync(addProductViewModel);
                if (result.CreatedSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            await ConfigureViewData();
            return View(addProductViewModel);
        }

        // GET: Products/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var result = await _dashboardProductsService.GetProductDetailsAsync(id);
            if(result == null)
            {
                return NotFound();
            }
            await ConfigureViewData();
            return View(result);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(EditProductViewModel editProductViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardProductsService.EditProductAsync(editProductViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Index));
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            var productViewModel = await _dashboardProductsService.GetProductDetailsAsync(editProductViewModel.Id);
            await ConfigureViewData();
            return View(productViewModel);
        }

        private async Task ConfigureViewData()
        {
            ViewBag.MainCategories = await _dashboardMainCategoriesService.GetAllMainCategoriesAsync();
            var offersList = (await _dashboardOffersService.GetAllOffersAsync()).ToList();
            offersList.Insert(0, new OfferViewModel { Id = 0, Name = "-- Select Offer --" });
            ViewBag.Offers = offersList;
            ViewBag.Markets = await _dashboardMarketsService.GetAllMarketsAsync();
            ViewBag.Brands = await _dashboardBrandsService.GetAllBrandsAsync();
        }

        // POST: Products/Delete/5
        [HttpPost]
        public async Task<ActionResult> Delete(int id)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardProductsService.DeleteProductAsync(id);
                if (result.ExcuteSuccessfully)
                {
                    return Json(id);
                }
                return Json(result.ErrorMessages.FirstOrDefault());
            }
            return Json(0);
        }

        // GET: Products/EditPrice/5
        public async Task<ActionResult> EditPrice(int id)
        {
            var result = await _dashboardProductsService.GetPriceDetailsAsync(id);
            if (result == null)
            {
                return NotFound();
            }
            ViewBag.Markets = await _dashboardMarketsService.GetAllMarketsAsync();
            return View(result);
        }

        // POST: Products/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> EditPrice(EditPriceViewModel editPriceViewModel)
        {
            if (ModelState.IsValid)
            {
                var result = await _dashboardProductsService.EditPriceAsync(editPriceViewModel);
                if (result.ExcuteSuccessfully)
                {
                    return RedirectToAction(nameof(Edit), new { id = editPriceViewModel.Product_Id });
                }
                ModelState.AddModelError("", result.ErrorMessages.FirstOrDefault());
            }
            return RedirectToAction(nameof(EditPrice), new { id = editPriceViewModel.Id });
        }
    }
}
