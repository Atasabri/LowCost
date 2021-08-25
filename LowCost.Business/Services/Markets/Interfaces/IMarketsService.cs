using LowCost.Infrastructure.DTOs.Markets;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Markets.Interfaces
{
    public interface IMarketsService
    {
        /// <summary>
        /// Get Markets List (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<MarketDTO>> GetMarketsAsync(PagingParameters pagingParameters);
    }
}
