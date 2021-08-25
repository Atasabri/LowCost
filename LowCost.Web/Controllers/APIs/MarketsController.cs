using LowCost.Business.Services.Brands.Interfaces;
using LowCost.Business.Services.Markets.Interfaces;
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
    public class MarketsController : APIController
    {
        private readonly IMarketsService _marketsService;

        public MarketsController(IMarketsService marketsService)
        {
            this._marketsService = marketsService;
        }

        [HttpGet("GetMarkets")]
        public async Task<IActionResult> GetMarkets([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _marketsService.GetMarketsAsync(pagingParameters));
        }
    }
}
