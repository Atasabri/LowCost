using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Notifications
{
    public class NotificationDTO
    {
        public string Message { get; set; }
        public DateTime DateTime { get; set; }
        public int? Order_Id { get; set; }
        public int? Product_Id { get; set; }
    }
}
