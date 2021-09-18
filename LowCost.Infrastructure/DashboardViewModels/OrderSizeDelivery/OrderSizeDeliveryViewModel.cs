using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.OrderSizeDelivery
{
    public class OrderSizeDeliveryViewModel : BaseViewModel
    {
        [Display(Name = "Size From")]
        public double SizeFrom { get; set; }
        [Display(Name = "Size To")]
        public double SizeTo { get; set; }
        public double Delivery { get; set; }
    }
}
