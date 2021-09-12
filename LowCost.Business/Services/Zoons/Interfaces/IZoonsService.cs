using LowCost.Infrastructure.DTOs.Zoons;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Zoons.Interfaces
{
    public interface IZoonsService
    {
        /// <summary>
        /// Get Markets List (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ZoonDTO>> GetZoonsAsync(PagingParameters pagingParameters);
    }
}
