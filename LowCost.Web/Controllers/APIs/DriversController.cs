using LowCost.Business.Services.Notifications.Interfaces;
using LowCost.Business.Services.Orders.Interfaces;
using LowCost.Business.Services.User.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DTOs.User;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.APIs
{
    public class DriversController : AuthorizedDriverAPIController
    {
        private readonly IDriverService _driverService;
        private readonly IUserService _userService;
        private readonly IOrdersService _ordersService;
        private readonly INotificationsService _notificationsService;

        public DriversController(IDriverService driverService, IUserService userService,
            IOrdersService ordersService, INotificationsService notificationsService)
        {
            this._driverService = driverService;
            this._userService = userService;
            this._ordersService = ordersService;
            this._notificationsService = notificationsService;
        }

        [HttpPut("EditProfile")]
        public async Task<IActionResult> EditProfile([FromForm] EditProfileDTO editProfileDTO)
        {
            var result = await _driverService.EditProfileAsync(editProfileDTO);
            if (result.ExcuteSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("EditPassword")]
        public async Task<IActionResult> EditPassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
            var result = await _driverService.ChangePasswordAsync(changePasswordDTO);
            if (result.ExcuteSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Profile")]
        public async Task<IActionResult> Profile()
        {
            return Ok(await _driverService.ProfileAsync());
        }

        [HttpGet("GetDriverOrders")]
        public async Task<IActionResult> GetDriverOrders([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _ordersService.GetDriverOrdersAsync(pagingParameters));
        }

        [HttpGet("GetDriverPreviousOrders")]
        public async Task<IActionResult> GetDriverPreviousOrders([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _ordersService.GetDriverFinishedOrdersAsync(pagingParameters));
        }

        [HttpGet("GetOrder/{orderId}")]
        public async Task<IActionResult> GetOrder(int orderId)
        {
            return Ok(await _ordersService.GetDriverOrderDetailsAsync(orderId));
        }

        [HttpGet("GetDriverNotifications")]
        public async Task<IActionResult> GetUserNotifications([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _notificationsService.GetUserNotificationsAsync(pagingParameters));
        }

        [HttpPut("ChangeDriverCurrentLanguage/{lang}")]
        public async Task<IActionResult> ChangeDriverCurrentLanguage(Languages lang)
        {
            var result = await _userService.ChangeLoginedUserCurrentLanguageAsync(lang);
            if (result.ExcuteSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("StartOrder/{orderId}")]
        public async Task<IActionResult> StartOrder(int orderId)
        {
            var result = await _ordersService.StartOrderAsync(orderId);
            if (result.ExcuteSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("FinishOrder/{orderId}")]
        public async Task<IActionResult> FinishOrder(int orderId)
        {
            var result = await _ordersService.FinishOrderAsync(orderId);
            if (result.ExcuteSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
