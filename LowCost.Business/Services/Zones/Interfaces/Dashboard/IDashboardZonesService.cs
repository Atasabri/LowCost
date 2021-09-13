using LowCost.Infrastructure.DashboardViewModels.Zones;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Zones.Interfaces.Dashboard
{
    public interface IDashboardZonesService
    {
        /// <summary>
        /// Adding New Zone Asynchronous
        /// </summary>
        /// <param name="addZoneViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateZoneAsync(AddZoneViewModel addZoneViewModel);
        /// <summary>
        /// Edit Zone Asynchronous
        /// </summary>
        /// <param name="editZoneViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditZoneAsync(EditZoneViewModel editZoneViewModel);
        /// <summary>
        /// Delete Zone Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteZoneAsync(int id);
        /// <summary>
        /// Get Zones (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ZoneViewModel>> GetDashboardZonesAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Zone Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<ZoneViewModel> GetZoneDetailsAsync(int Id);
    }
}
