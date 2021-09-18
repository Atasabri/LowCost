using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.OrderSizeDelivery
{
    public class AddOrderSizeDeliveryViewModel
    {
        [Required]
        [Display(Name = "Size From")]
        public double SizeFrom { get; set; }
        [Required]
        [Display(Name = "Size To")]
        public double SizeTo { get; set; }
        [Required]
        public double Delivery { get; set; }
    }
}
