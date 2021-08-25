using LowCost.Infrastructure.DashboardViewModels.Orders;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Orders.Interfaces.Dashboard
{
    public interface IDashboardOrdersService
    {
        /// <summary>
        /// Get Orders Order By Desc (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingOrderViewModel>> GetOrdersAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Order Details Data Using Order Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<OrderViewModel> GetOrderDetailsAsync(int id);
        /// <summary>
        /// Close Order Using Order Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> CloseOrderAsync(int id);
        /// <summary>
        /// Adding Status to Order Asynchronous
        /// </summary>
        /// <param name="addStatusViewModel"></param>
        /// <returns></returns>
        Task<CreateState> AddOrderStatusAsync(AddOrderStatusViewModel addStatusViewModel);
        /// <summary>
        /// Assign Driver to Order Asynchronous
        /// </summary>
        /// <param name="addOrderDriverViewModel"></param>
        /// <returns></returns>
        Task<ActionState> AssignOrderDriverAsync(AddOrderDriverViewModel addOrderDriverViewModel);
        /// <summary>
        /// Get Order All Statuses Using Order Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<IEnumerable<OrderStatusesViewModel>> GetOrderStatusesAsync(int id);
        /// <summary>
        /// Get All Statuses Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<StatusesViewModel>> GetAllStatusesAsync();
    }
}
