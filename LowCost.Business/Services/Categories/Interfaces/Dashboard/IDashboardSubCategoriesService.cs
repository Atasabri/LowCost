using LowCost.Infrastructure.DashboardViewModels.Categories;
using LowCost.Infrastructure.DashboardViewModels.Categories.Categories;
using LowCost.Infrastructure.DashboardViewModels.Categories.SubCategories;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Categories.Interfaces.Dashboard
{
    public interface IDashboardSubCategoriesService
    {
        /// <summary>
        /// Adding New Sub Category Asynchronous
        /// </summary>
        /// <param name="addSubCategoryViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateSubCategoryAsync(AddSubCategoryViewModel addSubCategoryViewModel);
        /// <summary>
        /// Edit Sub Category Asynchronous
        /// </summary>
        /// <param name="editSubCategoryViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditSubCategoryAsync(EditSubCategoryViewModel editSubCategoryViewModel);
        /// <summary>
        /// Delete Sub Category Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteSubCategoryAsync(int id);
        /// <summary>
        /// Get Sub Categories (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<SubCategoryViewModel>> GetDashboardSubCategoriesAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Sub Category Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<SubCategoryViewModel> GetSubCategoryDetailsAsync(int Id);
        /// <summary>
        /// Get All Sub Categories Using Category Id Asynchronous
        /// </summary>
        /// <param name="catId"></param>
        /// <returns></returns>
        Task<IEnumerable<SubCategoryViewModel>> GetAllSubCategoriesUsingCategoryIdAsync(int catId);
    }
}
