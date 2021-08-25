using LowCost.Business.Services.Categories.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.Apis
{
    public class CategoriesController : APIController
    {
        private readonly ICategoriesService _categoriesService;

        public CategoriesController(ICategoriesService categoriesService)
        {
            this._categoriesService = categoriesService;
        }

        [HttpGet("GetMainCategories")]
        public async Task<IActionResult> GetMainCategories([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _categoriesService.GetMainCategoriesAsync(pagingParameters));
        }

        [HttpGet("GetCategories")]
        public async Task<IActionResult> GetCategories([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _categoriesService.GetCategoriesAsync(pagingParameters));
        }

        [HttpGet("GetCategoriesIncludeSubCategories/{mainCategoryId}")]
        public async Task<IActionResult> GetCategoriesIncludeSubCategories(int mainCategoryId,  [FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _categoriesService.GetCategoriesIncludeSubCategoriesAsync(mainCategoryId, pagingParameters));
        }

        [HttpGet("GetCategories/{mainCategoryId}")]
        public async Task<IActionResult> GetCategoriesUsingMainCategoryId(int mainCategoryId, [FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _categoriesService.GetCategoriesUsingMainCategoryIdAsync(mainCategoryId, pagingParameters));
        }

        [HttpGet("GetSubCategories/{categoryId}")]
        public async Task<IActionResult> GetSubCategories(int categoryId, [FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _categoriesService.GetSubCategoriesAsync(categoryId, pagingParameters));
        }
    }
}
