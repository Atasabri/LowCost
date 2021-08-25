using LowCost.Infrastructure.DashboardViewModels.Statuses;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Statuses.Interfaces.Dashboard
{
    public interface IDashboardStatusesService
    {
        /// <summary>
        /// Adding New Status Asynchronous
        /// </summary>
        /// <param name="addStatusViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateStatusAsync(AddStatusViewModel addStatusViewModel);
        /// <summary>
        /// Edit Status Asynchronous
        /// </summary>
        /// <param name="editStatusViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditStatusAsync(EditStatusViewModel editStatusViewModel);
        /// <summary>
        /// Delete Status Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteStatusAsync(int id);
        /// <summary>
        /// Get Statuses (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<StatusViewModel>> GetDashboardStatusesAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Status Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<StatusViewModel> GetStatusDetailsAsync(int Id);
        /// <summary>
        /// Get All Statuses Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<StatusViewModel>> GetAllStatusesAsync();
    }
}
