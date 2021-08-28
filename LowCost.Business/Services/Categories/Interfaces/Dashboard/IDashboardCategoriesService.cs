using LowCost.Infrastructure.DashboardViewModels.Categories;
using LowCost.Infrastructure.DashboardViewModels.Categories.Categories;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Categories.Interfaces.Dashboard
{
    public interface IDashboardCategoriesService
    {
        /// <summary>
        /// Adding New Category Asynchronous
        /// </summary>
        /// <param name="addCategoryViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateCategoryAsync(AddCategoryViewModel addCategoryViewModel);
        /// <summary>
        /// Edit Category Asynchronous
        /// </summary>
        /// <param name="editCategoryViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditCategoryAsync(EditCategoryViewModel editCategoryViewModel);
        /// <summary>
        /// Delete Category Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteCategoryAsync(int id);
        /// <summary>
        /// Get Categories (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<CategoryViewModel>> GetDashboardCategoriesAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Category Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<CategoryViewModel> GetCategoryDetailsAsync(int Id);
        /// <summary>
        /// Get All Categories Using Main Category Id Asynchronous
        /// </summary>
        /// <param name="mainCatId"></param>
        /// <returns></returns>
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesUsingMainCategoryIdAsync(int mainCatId);
        /// <summary>
        /// Re Order Categories List Asynchronous
        /// </summary>
        /// <param name="orderListItems"></param>
        /// <returns></returns>
        Task<ActionState> OrderCategoriesListAsync(int[]  orderListItems);
        /// <summary>
        /// Changing Category Viewing in App Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <param name="viewInApp"></param>
        /// <returns></returns>
        Task<ActionState> ChangeViewInAppAsync(int Id, bool viewInApp);
    }
}
