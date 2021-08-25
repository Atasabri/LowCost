using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Infrastructure.AppSettings;
using LowCost.Infrastructure.Hubs;
using LowCost.Infrastructure.NotificationsHelpers;
using LowCost.Infrastructure.NotificationsHelpers.MobileNotificationModels;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Notifications;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.Text;
using System.Threading.Tasks;


namespace LowCost.Repo.Repositories.Implementation.Notifications
{
    public class NotificationsRepository : GenericRepository<Notification>, INotificationsRepository
    {
        private readonly IHubContext<RealTimeHub> _hubContext;
        private readonly AppSettings _appSettings;
        public NotificationsRepository(DB context, AppSettings appSettings, IHubContext<RealTimeHub> hubContext)
            : base(context)
        {
            this._hubContext = hubContext;
            this._appSettings = appSettings;
        }

        public async Task WebNotifyToAllAsync(WebNotificationState webNotificationState)
        {
            await _hubContext.Clients.All.SendAsync(webNotificationState.MethodName,
                JsonConvert.SerializeObject(webNotificationState.Data,
                new IsoDateTimeConverter() { DateTimeFormat = "dd-MM-yyyy HH:mm" }));
        }

        private async Task<IEnumerable<string>> NotifyAsync(object payload)
        {
            try
            {
                WebRequest tRequest = WebRequest.Create("https://fcm.googleapis.com/fcm/send");
                tRequest.Method = "post";
                // ServerKey - Key from Firebase cloud messaging server  
                tRequest.Headers.Add(string.Format("Authorization: key={0}", _appSettings.FirebaseMessaging.Serverkey));
                // SenderId - From firebase project setting  
                tRequest.Headers.Add(string.Format("Sender: id={0}", _appSettings.FirebaseMessaging.SenderId));
                tRequest.ContentType = "application/json";
                // DeviceId - obtained when the device is registered

                // Notify Sending Request
                string postbody = JsonConvert.SerializeObject(payload).ToString();
                byte[] byteArray = Encoding.UTF8.GetBytes(postbody);
                tRequest.ContentLength = byteArray.Length;
                using (Stream dataStream = await tRequest.GetRequestStreamAsync())
                {
                    await dataStream.WriteAsync(byteArray, 0, byteArray.Length);
                    using (WebResponse tResponse = await tRequest.GetResponseAsync())
                    {
                        using (Stream dataStreamResponse = tResponse.GetResponseStream())
                        {
                            if (dataStreamResponse != null) using (StreamReader tReader = new StreamReader(dataStreamResponse))
                                {
                                    string sResponseFromServer = await tReader.ReadToEndAsync();
                                    return new string[] { sResponseFromServer };
                                }
                        }
                    }
                }
                return new string[] { "No response" };
            }
            catch (Exception exp)
            {
                return new string[] { exp.Message };
            }
        }

        public async Task<IEnumerable<string>> NotifyDevicesAsync(DeviceNotifyState deviceNotifyState)
        {
            object payload = new
            {
                registration_ids = deviceNotifyState.Devices,
                notification = new
                {
                    body = deviceNotifyState.Body,
                    title = deviceNotifyState.Title,
                },
                data = deviceNotifyState.NotificationHiddenData,
                priority = "high"
            };

            return await NotifyAsync(payload);
        }

        public async Task<IEnumerable<string>> NotifyTopicAsync(TopicNotifyState topicNotifyState)
        {
            object payload = new
            {
                to = "/topics/" + topicNotifyState.Topic,
                data = new
                {
                    data = topicNotifyState.NotificationHiddenData,
                    body = topicNotifyState.Body,
                    title = topicNotifyState.Title,
                },
                priority = "high"
            };

            return await NotifyAsync(payload);
        }
    }
}
