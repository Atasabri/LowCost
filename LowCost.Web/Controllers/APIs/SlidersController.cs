using LowCost.Business.Services.Sliders.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.APIs
{
    public class SlidersController : APIController
    {
        private readonly ISlidersService _slidersService;

        public SlidersController(ISlidersService slidersService)
        {
            this._slidersService = slidersService;
        }

        [HttpGet("GetSliders")]
        public async Task<IActionResult> GetSliders([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _slidersService.GetSlidersAsync(pagingParameters));
        }
    }
}
