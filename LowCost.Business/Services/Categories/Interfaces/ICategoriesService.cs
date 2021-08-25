using LowCost.Infrastructure.DTOs.Categories;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Categories.Interfaces
{
    public interface ICategoriesService
    {
        /// <summary>
        /// Get Main Categories List (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<MainCategoryDTO>> GetMainCategoriesAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Categories List (Asynchronous & Paging) Using Main Category Id
        /// </summary>
        /// <param name="mainCatId"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<CategoryDTO>> GetCategoriesUsingMainCategoryIdAsync(int mainCatId, PagingParameters pagingParameters);
        /// <summary>
        /// Get Categories List (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<CategoryDTO>> GetCategoriesAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Categories List Include Sub Categories(Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<CategoryIncludeSubCategoriesDTO>> GetCategoriesIncludeSubCategoriesAsync(int mainCatId, PagingParameters pagingParameters);
        /// <summary>
        /// Get Sub Categories List (Asynchronous & Paging) Using Category Id
        /// </summary>
        /// <param name="catId"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<SubCategoryDTO>> GetSubCategoriesAsync(int catId, PagingParameters pagingParameters);
    }
}
