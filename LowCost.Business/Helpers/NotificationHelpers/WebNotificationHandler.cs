using LowCost.Business.Hubs;
using LowCost.Infrastructure.NotificationsHelpers;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Helpers.NotificationHelpers
{
    public class WebNotificationHandler
    {
        private readonly IHubContext<RealTimeHub> _hubContext;

        public WebNotificationHandler(IHubContext<RealTimeHub> hubcontext)
        {
            this._hubContext = hubcontext;
        }
        public async Task WebNotifyToAllDashboardAdminsAsync(WebNotificationState webNotificationState)
        {
            await _hubContext.Clients.All.SendAsync(webNotificationState.MethodName,
                JsonConvert.SerializeObject(webNotificationState.Data,
                new IsoDateTimeConverter() { DateTimeFormat = "dd-MM-yyyy HH:mm" }));
        }

        public async Task WebNotifyDashboardGroupsAsync(WebNotificationState webNotificationState)
        {
            await _hubContext.Clients.Groups(webNotificationState.Groups).SendAsync(webNotificationState.MethodName,
                JsonConvert.SerializeObject(webNotificationState.Data,
                new IsoDateTimeConverter() { DateTimeFormat = "dd-MM-yyyy HH:mm" }));
        }
    }
}
