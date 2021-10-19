using LowCost.Business.Services.Orders.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DTOs.Orders;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.APIs
{
    public class OrdersController : AuthorizedAPIController
    {
        private readonly IOrdersService _ordersService;

        public OrdersController(IOrdersService ordersService)
        {
            this._ordersService = ordersService;
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] AddOrderDTO addOrderDTO)
        {
            var result = await _ordersService.AddOrderAsync(addOrderDTO);
            if (result.CreatedSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("OrderPreview")]
        public async Task<IActionResult> OrderPreview([FromBody] AddOrderDTO addOrderDTO)
        {
            var result = await _ordersService.GenerateOrderAsync(addOrderDTO);
            if (result.OrderGeneratedSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("GetOrders")]
        public async Task<IActionResult> GetOrders([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _ordersService.GetOrdersAsync(pagingParameters));
        }

        [HttpGet("GetOrder/{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            return Ok(await _ordersService.GetOrderDetailsAsync(orderId));
        }

        [HttpPost("CheckCode/{code}")]
        public async Task<IActionResult> CheckCode(string code)
        {
            return Ok(await _ordersService.CheckPromoCodeAsync(code));
        }

        [AllowAnonymous]
        [HttpPost("CalculateOrderSavedMoney")]
        public async Task<IActionResult> CalculateOrderSavedMoney([FromBody] List<AddOrderDetailsDTO> productsDetails)
        {
            return Ok(await _ordersService.CalculateUserSavedMoneyAsync(productsDetails));
        }

        [HttpPost("CloseOrder/{orderId}")]
        public async Task<IActionResult> CloseOrder(int orderId)
        {
            return Ok(await _ordersService.CloseOrderAsync(orderId));
        }

        [HttpPost("CheckOrderDelivery")]
        public async Task<IActionResult> CheckOrderDelivery([FromBody] List<AddOrderDetailsDTO> orderDetails)
        {
            return Ok(await _ordersService.GetOrderDeliveryAsync(orderDetails));
        }

        [HttpGet("GetActionUserActiveOrdersCount")]
        public async Task<IActionResult> GetActionUserActiveOrdersCount()
        {
            return Ok(await _ordersService.GetActiveOrdersCountAsync());
        }
    }
}
