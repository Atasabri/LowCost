using LowCost.Business.Services.Notifications.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.APIs
{
    public class NotificationsController : AuthorizedAPIController
    {
        private readonly INotificationsService _notificationsservice;

        public NotificationsController(INotificationsService notificationsservice)
        {
            this._notificationsservice = notificationsservice;
        }

        [HttpGet("GetUserNotifications")]
        public async Task<IActionResult> GetUserNotifications([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _notificationsservice.GetUserNotificationsAsync(pagingParameters));
        }
    }
}
