using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.NotificationsHelpers.MobileNotificationModels
{
    public class MultiTopicsNotifyState : MobileNotificationState
    {
        public string[] Topics { get; set; }
    }
}
