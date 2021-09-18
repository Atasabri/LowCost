using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Orders
{
    public class OrderDetailsViewModel : BaseViewModel
    {
        public double Price { get; set; }
        public int Quantity { get; set; }
        public double Size { get; set; }

        public int Product_Id { get; set; }
        public int Market_Id { get; set; }

        public string ProductName { get; set; }

        public string MarketName { get; set; }
    }
}
