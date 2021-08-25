using LowCost.Infrastructure.DTOs.Products;
using LowCost.Infrastructure.Filtration;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Products.Interfaces
{
    public interface IProductsService
    {
        /// <summary>
        /// Get Products Order By Desc (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductDTO>> GetProductsAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Products Order By Number of Sell Desc (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductDTO>> GetProductsMostSellAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Products With Discount Order By Desc (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductDTO>> GetProductsHasDiscountAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Products With Zero Cost Order By Desc (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductDTO>> GetProductsWithZeroCostAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Products Recommended For Product (Asynchronous & Paging)
        /// </summary>
        /// <param name="productId"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductDTO>> GetProductsRecommendedAsync(int productId, PagingParameters pagingParameters);
        /// <summary>
        /// Get Products Using Filtration & Paging Data (Asynchronous & Paging)
        /// </summary>
        /// <param name="productsFiltration"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductDTO>> GetProductsWithFiltrationAsync(ProductsFiltration productsFiltration);
        /// <summary>
        /// Get Products Using Category Id (Asynchronous & Paging)
        /// </summary>
        /// <param name="catId"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductDTO>> GetProductsUsingCategoryIdAsync(int catId, PagingParameters pagingParameters);
        /// <summary>
        /// Get Products Using Sub Category Id (Asynchronous & Paging)
        /// </summary>
        /// <param name="subCatId"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductDTO>> GetProductsUsingSubCategoryIdAsync(int subCatId, PagingParameters pagingParameters);
        /// <summary>
        /// Get Products Using Brand Id (Asynchronous & Paging)
        /// </summary>
        /// <param name="brandId"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductDTO>> GetProductsUsingBrandIdAsync(int brandId, PagingParameters pagingParameters);
        /// <summary>
        /// Get Single Product Using Product Id (Asynchronous)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ProductDTO> GetProductAsync(int id);
    }
}
