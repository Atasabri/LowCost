using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Orders
{
    public class OrderStatusesViewModel : BaseViewModel
    {
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
    }
}
