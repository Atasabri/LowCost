using LowCost.Domain.Models;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.NotificationsHelpers;
using LowCost.Infrastructure.NotificationsHelpers.MobileNotificationModels;
using LowCost.Repo.UnitOfWork;
using LowCost.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Helpers
{
    public class NotificationHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public NotificationHandler(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> stringLocalizer)
        {
            this._unitOfWork = unitOfWork;
            this._stringLocalizer = stringLocalizer;
        }

        public async Task ChangeStatusNotify(int order_Id)
        {
            var orderNotificationState = new OrderNotificationState()
            {
                Order_Id = order_Id,
                Data = new { Order_Id = order_Id },
                User_Title_Key = "Order #{0}",
                User_Title_Arguments = new object[] { order_Id },
                User_Body_Key = "Order With Id #{0} Status Changes",
                User_Body_Arguments = new object[] { order_Id },
                Driver_Title_Key = "Order #{0}",
                Driver_Title_Arguments = new object[] { order_Id },
                Driver_Body_Key = "Order With Id #{0} Status Changes",
                Driver_Body_Arguments = new object[] { order_Id }
            };

            await NotifyAsync(orderNotificationState);
        }

        public async Task AssignDriverNotify(int order_Id)
        {
            var orderNotificationState = new OrderNotificationState()
            {
                Order_Id = order_Id,
                Data = new { Order_Id = order_Id },
                User_Title_Key = "Order #{0}",
                User_Title_Arguments = new object[] { order_Id },
                User_Body_Key = "Order With Id #{0} Assigned To Driver",
                User_Body_Arguments = new object[] { order_Id },
                Driver_Title_Key = "Order #{0}",
                Driver_Title_Arguments = new object[] { order_Id },
                Driver_Body_Key = "New Order Assigned to You #{0}",
                Driver_Body_Arguments = new object[] { order_Id }
            };

            await NotifyAsync(orderNotificationState);
        }

        public async Task NotifyAsync(OrderNotificationState orderNotificationState)
        {
            var order = await _unitOfWork.OrdersRepository.FindElementAsync(order => order.Id == orderNotificationState.Order_Id, string.Format("{0},{1}", nameof(Order.User), nameof(Order.Driver)));

            var stringLocalizerUser = _stringLocalizer.WithCulture(new CultureInfo(order.User.CurrentLangauge.ToString()));

            string messageUserTitle = stringLocalizerUser[orderNotificationState.User_Title_Key, orderNotificationState.User_Title_Arguments];
            string messageUserBody = stringLocalizerUser[orderNotificationState.User_Body_Key, orderNotificationState.User_Body_Arguments];

            var notificationState = new TopicNotifyState()
            {
                Topic = order.User_Id,
                Title = messageUserTitle,
                Body = messageUserBody,
                NotificationHiddenData = orderNotificationState.Data
            };
            // Sending Notification To User Device 
            await _unitOfWork.NotificationsRepository.NotifyTopicAsync(notificationState);
            // Adding Notification Item To User
            await _unitOfWork.NotificationsRepository.CreateAsync(new Notification()
            {
                DateTime = DateTimeProvider.GetEgyptDateTime(),
                Message = messageUserBody,
                Order_Id = order.Id,
                User_Id = order.User_Id
            });
            // Check If Order Has Driver
            if (!string.IsNullOrEmpty(order.Driver_Id))
            {
                var stringLocalizerDriver = _stringLocalizer.WithCulture(new CultureInfo(order.Driver.CurrentLangauge.ToString()));

                string messageDriverTitle = stringLocalizerDriver[orderNotificationState.Driver_Title_Key, orderNotificationState.Driver_Title_Arguments];
                string messageDriverBody = stringLocalizerDriver[orderNotificationState.Driver_Body_Key, orderNotificationState.Driver_Body_Arguments];
                var driverNotificationState = new TopicNotifyState()
                {
                    Topic = order.Driver_Id,
                    Title = messageDriverTitle,
                    Body = messageDriverBody,
                    NotificationHiddenData = orderNotificationState.Data
                };
                // Sending Notification To Driver Device 
                await _unitOfWork.NotificationsRepository.NotifyTopicAsync(driverNotificationState);
                // Adding Notification Item To Driver
                await _unitOfWork.NotificationsRepository.CreateAsync(new Notification()
                {
                    DateTime = DateTimeProvider.GetEgyptDateTime(),
                    Message = messageDriverBody,
                    Order_Id = order.Id,
                    User_Id = order.Driver_Id
                });
            }
            await _unitOfWork.SaveAsync();
        }

        public async Task NotifyUserOrderAsync(int orderId, string messageKey)
        {
            var order = await _unitOfWork.OrdersRepository.FindElementAsync(order => order.Id == orderId, string.Format("{0}", nameof(Order.User)));

            var stringLocalizerUser = _stringLocalizer.WithCulture(new CultureInfo(order.User.CurrentLangauge.ToString()));
            var notificationState = new TopicNotifyState()
            {
                Topic = order.User_Id,
                Title = stringLocalizerUser["Order #{0}", order.Id],
                Body = stringLocalizerUser[messageKey, order.Id],
                NotificationHiddenData = new { Order_Id = order.Id }
            };
            // Sending Notification To User Device 
            await _unitOfWork.NotificationsRepository.NotifyTopicAsync(notificationState);
            // Adding Notification Item To User
            await _unitOfWork.NotificationsRepository.CreateAsync(new Notification()
            {
                DateTime = DateTimeProvider.GetEgyptDateTime(),
                Message = notificationState.Body,
                Order_Id = order.Id,
                User_Id = order.User_Id
            });;
            await _unitOfWork.SaveAsync();
        }
    }
}
