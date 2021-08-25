using LowCost.Infrastructure.DashboardViewModels.Markets;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Markets.Interfaces.Dashboard
{
    public interface IDashboardMarketsService
    {
        /// <summary>
        /// Adding New Market Asynchronous
        /// </summary>
        /// <param name="addMarketViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateMarketAsync(AddMarketViewModel addMarketViewModel);
        /// <summary>
        /// Edit Market Asynchronous
        /// </summary>
        /// <param name="editMarketViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditMarketAsync(EditMarketViewModel editMarketViewModel);
        /// <summary>
        /// Delete Market Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteMarketAsync(int id);
        /// <summary>
        /// Get Markets (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<MarketViewModel>> GetDashboardMarketsAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Market Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<MarketViewModel> GetMarketDetailsAsync(int Id);
        /// <summary>
        /// Get All Markets Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MarketViewModel>> GetAllMarketsAsync();
    }
}
