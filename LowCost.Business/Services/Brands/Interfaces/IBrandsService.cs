using LowCost.Infrastructure.DTOs.Brand;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Brands.Interfaces
{
    public interface IBrandsService
    {
        /// <summary>
        /// Get Brands List (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<BrandDTO>> GetBrandsAsync(PagingParameters pagingParameters);
    }
}
