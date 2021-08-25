using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Orders
{
    public class AddOrderDriverViewModel
    {
        [Required]
        public int Order_Id { get; set; }
        [Required]
        public string Driver_Id { get; set; }
    }
}
