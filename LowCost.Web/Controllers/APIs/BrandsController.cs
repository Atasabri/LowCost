using LowCost.Business.Services.Brands.Interfaces;
using LowCost.Business.Services.Notifications.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.APIs
{
    public class BrandsController : APIController
    {
        private readonly IBrandsService _brandsService;

        public BrandsController(IBrandsService brandsService)
        {
            this._brandsService = brandsService;
        }

        [HttpGet("GetBrands")]
        public async Task<IActionResult> GetBrands([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _brandsService.GetBrandsAsync(pagingParameters));
        }
    }
}
