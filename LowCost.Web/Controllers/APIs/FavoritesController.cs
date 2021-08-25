using LowCost.Business.Services.User.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DTOs.User.Favorites;
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
    public class FavoritesController : AuthorizedAPIController
    {
        private readonly IFavoritesService _favoritesService;

        public FavoritesController(IFavoritesService favoritesService)
        {
            this._favoritesService = favoritesService;
        }

        [HttpGet("GetFavorites")]
        public async Task<IActionResult> GetFavorites([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _favoritesService.GetUserFavoritesAsync(pagingParameters));
        }

        [HttpPost("LikeProduct")]
        public async Task<IActionResult> LikeProduct([FromBody] AddOrRemoveProductToFavoritesDTO addProductToFavoritesDTO)
        {
            var result = await _favoritesService.LikeProductAsync(addProductToFavoritesDTO);
            if (result.ExcuteSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
