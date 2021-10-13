using LowCost.Infrastructure.DashboardViewModels.Orders;
using LowCost.Infrastructure.DashboardViewModels.Products;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Search.Interfaces.Dashboard
{
    public interface IDashboardSearchService
    {
        /// <summary>
        /// Search in Products Using Name or Serial Number (Asynchronous & Paging)
        /// </summary>
        /// <param name="searchTerms"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingProductViewModel>> SearchProductsAsync(string searchTerms, PagingParameters pagingParameters);
        /// <summary>
        /// Search in Orders Using Order Id Or Stock Id (Asynchronous & Paging)
        /// </summary>
        /// <param name="searchOrdersViewModel"></param>
        /// <returns></returns>
        Task<PagedResult<ListingOrderViewModel>> SearchOrdersAsync(SearchOrdersViewModel searchOrdersViewModel);
    }
}
