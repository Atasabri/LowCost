using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Orders
{
    public class PromoCodeDTO
    {
        public bool PromoCodeFound { get; set; }
        public double DiscountPercent { get; set; }
    }
}
