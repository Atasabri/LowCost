using LowCost.Business.Services.Offers.Interfaces;
using LowCost.Infrastructure.BaseService;
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
    [Authorize(Roles = Constants.UserRoleName, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [AllowAnonymous]
    public class OffersController : APIController
    {
        private readonly IOffersService _offersService;

        public OffersController(IOffersService offersService)
        {
            this._offersService = offersService;
        }

        [HttpGet("GetOffers")]
        public async Task<IActionResult> GetOffers([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _offersService.GetOffersAsync(pagingParameters));
        }

        [HttpGet("GetLowCostOffer")]
        public async Task<IActionResult> GetLowCostOffer()
        {
            return Ok(await _offersService.GetLowCostOfferAsync());
        }

        [HttpGet("GetOfferProducts/{offerId}")]
        public async Task<IActionResult> GetOfferProducts(int offerId, [FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _offersService.GetOfferProductsAsync(offerId, pagingParameters));
        }
    }
}
