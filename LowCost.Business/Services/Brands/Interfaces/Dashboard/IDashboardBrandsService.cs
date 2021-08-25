using LowCost.Infrastructure.DashboardViewModels.Brand;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Brands.Interfaces.Dashboard
{
    public interface IDashboardBrandsService
    {
        /// <summary>
        /// Adding New Brand Asynchronous
        /// </summary>
        /// <param name="addBrandViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateBrandAsync(AddBrandViewModel addBrandViewModel);
        /// <summary>
        /// Edit Brand Asynchronous
        /// </summary>
        /// <param name="editBrandViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditBrandAsync(EditBrandViewModel editBrandViewModel);
        /// <summary>
        /// Delete Brand Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteBrandAsync(int id);
        /// <summary>
        /// Get Brands (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<BrandViewModel>> GetDashboardBrandsAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Brand Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<BrandViewModel> GetBrandDetailsAsync(int Id);
        /// <summary>
        /// Get All Brands Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<BrandViewModel>> GetAllBrandsAsync();
    }
}
