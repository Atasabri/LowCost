using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Orders
{
    public class OrderStatusDTO
    {
        public DateTime DateTime{ get; set; }
        public string Status { get; set; }
    }
}
