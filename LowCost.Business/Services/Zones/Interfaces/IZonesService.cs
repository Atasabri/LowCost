using LowCost.Infrastructure.DTOs.Zones;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Zones.Interfaces
{
    public interface IZonesService
    {
        /// <summary>
        /// Get Markets List (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ZoneDTO>> GetZonesAsync(PagingParameters pagingParameters);
    }
}
