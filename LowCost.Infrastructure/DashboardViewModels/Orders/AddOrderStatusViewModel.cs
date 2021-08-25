using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Orders
{
    public class AddOrderStatusViewModel
    {
        public DateTime DateTime { get; set; } = DateTimeProvider.GetEgyptDateTime();

        [Required]
        public int Order_Id { get; set; }
        [Required]
        public int Status_Id { get; set; }
    }
}
