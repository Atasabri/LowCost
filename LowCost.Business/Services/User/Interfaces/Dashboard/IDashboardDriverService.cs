using LowCost.Infrastructure.DashboardViewModels.User;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.User.Interfaces.Dashboard
{
    public interface IDashboardDriverService
    {
        /// <summary>
        /// Adding New Driver Asynchronous
        /// </summary>
        /// <param name="addDriverViewModel"></param>
        /// <returns></returns>
        Task<ActionState> CreateDriverAsync(AddDriverViewModel addDriverViewModel);
        /// <summary>
        /// Delete Driver Using Id Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<IdentityResult> DeleteDriverAsync(string Id);
        /// <summary>
        /// Get All Drivers Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<DriverViewModel>> GetAllDriversAsync();
        /// <summary>
        /// Get Drivers (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<DriverViewModel>> GetDriversAsync(PagingParameters pagingParameters);
    }
}
