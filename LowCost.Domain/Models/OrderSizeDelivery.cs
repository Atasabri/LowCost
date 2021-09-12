using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Domain.Models
{
    public class OrderSizeDelivery : BaseModel
    {
        public double SizeFrom { get; set; }
        public double SizeTo { get; set; }
        public double Delivery { get; set; }
    }
}
