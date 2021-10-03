using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Orders
{
    public class CheckOrderDeliveryDTO
    {
        public double Delivery { get; set; }
        public List<string> ErrorMessages { get; set; }
    }
}
