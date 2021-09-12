using LowCost.Infrastructure.DashboardViewModels.Zoons;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Zoons.Interfaces.Dashboard
{
    public interface IDashboardZoonsService
    {
        /// <summary>
        /// Adding New Zoon Asynchronous
        /// </summary>
        /// <param name="addZoonViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateZoonAsync(AddZoonViewModel addZoonViewModel);
        /// <summary>
        /// Edit Zoon Asynchronous
        /// </summary>
        /// <param name="editZoonViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditZoonAsync(EditZoonViewModel editZoonViewModel);
        /// <summary>
        /// Delete Zoon Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteZoonAsync(int id);
        /// <summary>
        /// Get Zoons (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ZoonViewModel>> GetDashboardZoonsAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Zoon Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<ZoonViewModel> GetZoonDetailsAsync(int Id);
    }
}
