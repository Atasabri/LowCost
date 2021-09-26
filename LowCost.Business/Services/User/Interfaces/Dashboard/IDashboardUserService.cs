using LowCost.Infrastructure.DashboardViewModels.User.DashboardUsersViewModels;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.User.Interfaces.Dashboard
{
    public interface IDashboardUserService
    {
        /// <summary>
        /// Get Users (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingUserViewModel>> GetUsersAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Search In Users (Asynchronous & Paging)
        /// </summary>
        /// <param name="searchTerms"></param>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingUserViewModel>> SearchUsersAsync(string searchTerms, PagingParameters pagingParameters);
        /// <summary>
        /// Get User By Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserViewModel> GetUserDetailsAsync(string id);
        /// <summary>
        /// Get User Balance Details By User Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<UserBalanceDetailsViewModel> GetUserBalanceDetailsAsync(string id);
        /// <summary>
        /// Edit User Balance Asynchronous
        /// </summary>
        /// <param name="editBalanceViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditUserBalanceAsync(EditBalanceViewModel editBalanceViewModel);
    }
}
