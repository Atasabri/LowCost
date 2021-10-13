using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using Xedge.Infrastructure.Helpers;

namespace LowCost.Infrastructure.DashboardViewModels.Wallet
{
    public class UserTransactionViewModel
    {
        [Display(Name = "Transaction Type")]
        public TransactionTypes TransactionType { get; set; }
        public DateTime Date { get; set; } 
        public double Money { get; set; }
        public string Comment { get; set; }

        [Display(Name = "Created By")]
        public string CreatedBy { get; set; }
    }
}
