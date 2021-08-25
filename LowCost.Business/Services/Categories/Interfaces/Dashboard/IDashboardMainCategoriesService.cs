using LowCost.Infrastructure.DashboardViewModels.Categories;
using LowCost.Infrastructure.DashboardViewModels.Categories.MainCategories;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Categories.Interfaces.Dashboard
{
    public interface IDashboardMainCategoriesService
    {
        /// <summary>
        /// Adding New Main Category Asynchronous
        /// </summary>
        /// <param name="addMainCategoryViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateMainCategoryAsync(AddMainCategoryViewModel addMainCategoryViewModel);
        /// <summary>
        /// Edit Main Category Asynchronous
        /// </summary>
        /// <param name="editMainCategoryViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditMainCategoryAsync(EditMainCategoryViewModel editMainCategoryViewModel);
        /// <summary>
        /// Delete Main Category Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteMainCategoryAsync(int id);
        /// <summary>
        /// Get Main Categories (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<MainCategoryViewModel>> GetDashboardMainCategoriesAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Main Category Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<MainCategoryViewModel> GetMainCategoryDetailsAsync(int Id);
        /// <summary>
        /// Get All Main Categories Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<MainCategoryViewModel>> GetAllMainCategoriesAsync();

    }
}
