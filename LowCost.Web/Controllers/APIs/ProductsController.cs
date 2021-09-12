using LowCost.Business.Services.ProductFollowingUsersService.Interfaces;
using LowCost.Business.Services.Products.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.Filtration;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.APIs
{
    public class ProductsController : APIController
    {
        private readonly IProductsService _productsservice;
        private readonly IProductFollowingUsersService _productFollowingUsersService;

        public ProductsController(IProductsService productsservice, IProductFollowingUsersService productFollowingUsersService)
        {
            this._productsservice = productsservice;
            this._productFollowingUsersService = productFollowingUsersService;
        }

        [HttpGet("GetProducts")]
        public async Task<IActionResult> GetProducts([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _productsservice.GetProductsAsync(pagingParameters));
        }

        [HttpGet("GetProduct/{Id}")]
        public async Task<IActionResult> GetProduct(int Id)
        {
            return Ok(await _productsservice.GetProductAsync(Id));
        }

        [HttpGet("GetProductsHasDiscount")]
        public async Task<IActionResult> GetProductsHasDiscount([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _productsservice.GetProductsHasDiscountAsync(pagingParameters));
        }

        [HttpGet("GetProductsWithZeroCost")]
        public async Task<IActionResult> GetProductsWithZeroCost([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _productsservice.GetProductsWithZeroCostAsync(pagingParameters));
        }

        [HttpGet("GetProductsMostSell")]
        public async Task<IActionResult> GetProductsMostSellAsync([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _productsservice.GetProductsMostSellAsync(pagingParameters));
        }

        [HttpGet("GetRecommendedProducts/{productId}")]
        public async Task<IActionResult> GetRecommendedProducts(int productId, [FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _productsservice.GetProductsRecommendedAsync(productId, pagingParameters));
        }

        [HttpGet("GetProductsUsingCategoryId/{categoryId}")]
        public async Task<IActionResult> GetProductsUsingCategoryId(int categoryId, [FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _productsservice.GetProductsUsingCategoryIdAsync(categoryId, pagingParameters));
        }

        [HttpGet("GetProductsUsingSubCategoryId/{subCategoryId}")]
        public async Task<IActionResult> GetProductsUsingSubCategoryId(int subCategoryId, [FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _productsservice.GetProductsUsingSubCategoryIdAsync(subCategoryId, pagingParameters));
        }

        [HttpGet("GetProductsUsingBrandId/{brandId}")]
        public async Task<IActionResult> GetProductsUsingBrandId(int brandId, [FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _productsservice.GetProductsUsingBrandIdAsync(brandId, pagingParameters));
        }

        [HttpGet("GetProductsUsingFiltration")]
        public async Task<IActionResult> GetProductsUsingFiltration([FromQuery] ProductsFiltration productsFiltration)
        {
            return Ok(await _productsservice.GetProductsWithFiltrationAsync(productsFiltration));
        }

        [HttpPost("ProductsUsingFiltrationByPostRequest")]
        public async Task<IActionResult> ProductsUsingFiltration([FromBody] ProductsFiltration productsFiltration)
        {
            return Ok(await _productsservice.GetProductsWithFiltrationAsync(productsFiltration));
        }

        [Authorize(Roles = Constants.UserRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("FollowProduct/{product_Id}")]
        public async Task<IActionResult> FollowProduct(int product_Id)
        {
            var result = await _productFollowingUsersService.FollowProductAsync(product_Id);
            return Ok(result);
        }

        [Authorize(Roles = Constants.UserRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
        [HttpPost("UnFollowProduct/{product_Id}")]
        public async Task<IActionResult> UnFollowProduct(int product_Id)
        {
            var result = await _productFollowingUsersService.UnFollowProductAsync(product_Id);
            return Ok(result);
        }
    }
}
