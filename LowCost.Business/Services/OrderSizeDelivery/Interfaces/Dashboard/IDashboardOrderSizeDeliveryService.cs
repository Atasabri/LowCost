using LowCost.Infrastructure.DashboardViewModels.OrderSizeDelivery;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.OrderSizeDelivery.Interfaces.Dashboard
{
    public interface IDashboardOrderSizeDeliveryService
    {
        /// <summary>
        /// Adding New Order Size Delivery Asynchronous
        /// </summary>
        /// <param name="addOrderSizeDeliveryViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateOrderSizeDeliveryAsync(AddOrderSizeDeliveryViewModel addOrderSizeDeliveryViewModel);
        /// <summary>
        /// Edit Order Size Delivery Asynchronous
        /// </summary>
        /// <param name="editOrderSizeDeliveryViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditOrderSizeDeliveryAsync(EditOrderSizeDeliveryViewModel editOrderSizeDeliveryViewModel);
        /// <summary>
        /// Delete Order Size Delivery Item Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteOrderSizeDeliveryAsync(int id);
        /// <summary>
        /// Get Order Size Delivery Listing (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<OrderSizeDeliveryViewModel>> GetDashboardOrderSizeDeliverysAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Order Size Delivery Item Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<OrderSizeDeliveryViewModel> GetOrderSizeDeliveryDetailsAsync(int Id);
    }
}
