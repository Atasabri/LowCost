using LowCost.Business.Services.Zones.Interfaces;
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
    public class ZonesController : APIController
    {
        private readonly IZonesService _zonesService;

        public ZonesController(IZonesService zonesService)
        {
            this._zonesService = zonesService;
        }

        [HttpGet("GetZones")]
        public async Task<IActionResult> GetZones([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _zonesService.GetZonesAsync(pagingParameters));
        }


    }
}
