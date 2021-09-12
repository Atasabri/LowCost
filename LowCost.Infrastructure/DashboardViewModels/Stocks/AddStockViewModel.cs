using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Stocks
{
    public class AddStockViewModel 
    {
        [Required]
        public string Name { get; set; }
    }
}
