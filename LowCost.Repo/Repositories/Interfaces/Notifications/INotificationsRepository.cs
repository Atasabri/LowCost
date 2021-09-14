using LowCost.Domain.Models;
using LowCost.Infrastructure.NotificationsHelpers.MobileNotificationModels;
using LowCost.Infrastructure.NotificationsHelpers;
using LowCost.Repo.Generic;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Repo.Repositories.Interfaces.Notifications
{
    public interface INotificationsRepository : IGenericRepository<Notification>
    {
        /// <summary>
        /// Sending Notification To Mobile Device Using Device FCM Asynchronous
        /// </summary>
        /// <param name="deviceNotifyState"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> NotifyDevicesAsync(DeviceNotifyState deviceNotifyState);
        /// <summary>
        /// Sending Notification To Mobile Device Using Topic Asynchronous
        /// </summary>
        /// <param name="topicNotifyState"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> NotifyTopicAsync(TopicNotifyState topicNotifyState);
        /// <summary>
        /// Sending Notification To Mobile Devices Using Topics Asynchronous
        /// </summary>
        /// <param name="multiTopicsNotifyState"></param>
        /// <returns></returns>
        Task<IEnumerable<string>> NotifyMultiTopicsAsync(MultiTopicsNotifyState multiTopicsNotifyState);
    }
}
