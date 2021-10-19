using LowCost.Domain.Models;
using LowCost.Infrastructure.DTOs.Orders;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Orders.Interfaces
{
    public interface IOrdersService
    {
        /// <summary>
        /// Create Order Using All Order Details And Promo Code Asynchronous
        /// </summary>
        /// <param name="addOrderDTO"></param>
        /// <returns></returns>
        Task<CreateState> AddOrderAsync(AddOrderDTO addOrderDTO);
        /// <summary>
        /// Generate Order Without Adding It Asynchronous
        /// </summary>
        /// <param name="addOrderDTO"></param>
        /// <returns></returns>
        Task<GenerateOrderState> GenerateOrderAsync(AddOrderDTO addOrderDTO);
        /// <summary>
        /// Get Current Logined User Orders (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingOrderDTO>> GetOrdersAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Current Logined Driver Orders (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingOrderDTO>> GetDriverOrdersAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Current Logined Driver Finished Orders (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<ListingOrderDTO>> GetDriverFinishedOrdersAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Order All Details Using Order Id & Current User Asynchronous
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<OrderDTO> GetOrderDetailsAsync(int orderId);
        /// <summary>
        /// Get Order All Details Using Order Id & Current Driver Asynchronous
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        public Task<OrderDTO> GetDriverOrderDetailsAsync(int orderId);
        /// <summary>
        /// Close Order Before Assign to Driver Asynchronous
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<ActionState> CloseOrderAsync(int orderId);
        /// <summary>
        /// Return Discount Of Promo Code If Found Asynchronous
        /// </summary>
        /// <param name="promoCode"></param>
        /// <returns></returns>
        Task<PromoCodeDTO> CheckPromoCodeAsync(string promoCode);
        /// <summary>
        /// Calculate User Saved Money Asynchronous
        /// </summary>
        /// <param name="products"></param>
        /// <returns></returns>
        Task<double> CalculateUserSavedMoneyAsync(List<AddOrderDetailsDTO> productsDetails);
        /// <summary>
        /// Make Order Started Asynchronous
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<ActionState> StartOrderAsync(int orderId);
        /// <summary>
        /// Make Order Finished Asynchronous
        /// </summary>
        /// <param name="orderId"></param>
        /// <returns></returns>
        Task<ActionState> FinishOrderAsync(int orderId);
        /// <summary>
        /// Get Order Delivery Depend on All Products Size & Price With No Delivery Asynchronous
        /// </summary>
        /// <param name="orderDetails"></param>
        /// <returns></returns>
        Task<CheckOrderDeliveryDTO> GetOrderDeliveryAsync(List<AddOrderDetailsDTO> orderDetails);
        /// <summary>
        /// Get Current User Active Order (Not Closed & Not Finished) Count Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<int> GetActiveOrdersCountAsync();
    }


    public class GenerateOrderState
    {
        public bool OrderGeneratedSuccessfully { get; set; }
        public List<string> ErrorMessages { get; set; } = new List<string>();

        public Order Order { get; set; }
    }
}
