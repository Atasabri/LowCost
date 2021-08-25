using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.NotificationsHelpers
{
    public class WebNotificationState
    {
        public WebNotificationState(string methodName, object data)
        {
            this.MethodName = methodName;
            this.Data = data;
        }
        public string MethodName { get; set; }
        public object Data { get; set; }
        public string[] Users { get; set; } = new string[] { };
    }
}
