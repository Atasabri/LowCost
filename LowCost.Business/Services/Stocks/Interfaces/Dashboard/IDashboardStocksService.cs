using LowCost.Infrastructure.DashboardViewModels.Stocks;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Stocks.Interfaces.Dashboard
{
    public interface IDashboardStocksService
    {
        /// <summary>
        /// Adding New Stock Asynchronous
        /// </summary>
        /// <param name="addStockViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateStockAsync(AddStockViewModel addStockViewModel);
        /// <summary>
        /// Edit Stock Asynchronous
        /// </summary>
        /// <param name="editStockViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditStockAsync(EditStockViewModel editStockViewModel);
        /// <summary>
        /// Delete Stock Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteStockAsync(int id);
        /// <summary>
        /// Get Stocks (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<StockViewModel>> GetDashboardStocksAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get All Stocks Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<StockViewModel>> GetAllStocksAsync();
        /// <summary>
        /// Get Stock Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<StockViewModel> GetStockDetailsAsync(int Id);
    }
}
