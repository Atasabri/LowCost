using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.NotificationsHelpers
{
    public class OrderNotificationState
    {
        public int Order_Id { get; set; }
        public string User_Title_Key { get; set; }
        public object [] User_Title_Arguments { get; set; }
        public string Driver_Title_Key { get; set; }
        public object[] Driver_Title_Arguments { get; set; }
        public string User_Body_Key { get; set; }
        public object[] User_Body_Arguments { get; set; }
        public string Driver_Body_Key { get; set; }
        public object[] Driver_Body_Arguments { get; set; }
        public object Data { get; set; }
    }
}
