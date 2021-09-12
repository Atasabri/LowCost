using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.NotificationsHelpers
{
    public class ProductNotificationState
    {
        public int Product_Id { get; set; }
        public string Title_Key { get; set; }
        public object[] Title_Arguments { get; set; }
        public string Body_Key { get; set; }
        public object[] Body_Arguments { get; set; }
        public List<int> Stocks { get; set; }
        public object Data { get; set; }
    }
}
