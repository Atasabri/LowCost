using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LowCost.Business.Services.Sliders.Interfaces;
using LowCost.Infrastructure.DTOs.Sliders;
using LowCost.Infrastructure.Pagination;

namespace LowCost.Business.Services.Sliders.Interfaces
{
    public interface ISlidersService
    {
        /// <summary>
        /// Get Sliders Order Desc (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingparameters"></param>
        /// <returns></returns>
        Task<PagedResult<SliderDTO>> GetSlidersAsync(PagingParameters pagingparameters);
    }
}
