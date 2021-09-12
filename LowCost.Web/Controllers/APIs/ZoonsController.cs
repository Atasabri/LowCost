using LowCost.Business.Services.Zoons.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.APIs
{
    public class ZoonsController : APIController
    {
        private readonly IZoonsService _zoonsService;

        public ZoonsController(IZoonsService zoonsService)
        {
            this._zoonsService = zoonsService;
        }

        [HttpGet("GetZoons")]
        public async Task<IActionResult> GetZoonss([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _zoonsService.GetZoonsAsync(pagingParameters));
        }


    }
}
