using LowCost.Infrastructure.DTOs.Products;
using LowCost.Infrastructure.DTOs.User.Favorites;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.User.Interfaces
{
    public interface IFavoritesService
    {
        /// <summary>
        /// Adding Product To Favorites If Not In Exist or Delete From Favorites If Exist for Current User Asynchronous
        /// </summary>
        /// <param name="addProductToFavoritesDTO"></param>
        /// <returns></returns>
        Task<ActionState> LikeProductAsync(AddOrRemoveProductToFavoritesDTO addProductToFavoritesDTO);
        /// <summary>
        /// Get Current Logined User Favorites Products (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductDTO>> GetUserFavoritesAsync(PagingParameters pagingParameters);
    }
}
