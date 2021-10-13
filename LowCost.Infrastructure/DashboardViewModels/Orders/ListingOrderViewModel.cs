using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Orders
{
    public class ListingOrderViewModel : BaseViewModel
    {
        public string Driver_Id { get; set; }
        public DateTime DateTime { get; set; }
        public bool Paid { get; set; }
        public bool Closed { get; set; }
    }
}
