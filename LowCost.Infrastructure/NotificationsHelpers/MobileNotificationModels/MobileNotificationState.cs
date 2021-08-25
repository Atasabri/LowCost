using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.NotificationsHelpers.MobileNotificationModels
{
    public abstract class MobileNotificationState
    {
        public string Title { get; set; }
        public string Body { get; set; }
        public object NotificationHiddenData { get; set; }
    }
}
