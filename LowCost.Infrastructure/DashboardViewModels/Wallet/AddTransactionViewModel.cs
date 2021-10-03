using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Wallet
{
    public class AddTransactionViewModel
    {
        public double Money { get; set; }
        public string Comment { get; set; }
        [Required]
        public string UserId { get; set; }
    }
}
