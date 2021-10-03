using LowCost.Domain.Models.BaseModels;
using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using Xedge.Infrastructure.Helpers;

namespace LowCost.Domain.Models
{
    public class WalletTransaction : BaseModel
    {
        [Required]
        public string User_Id { get; set; } 

        public TransactionTypes TransactionType { get; set; }
        public DateTime Date { get; set; } = DateTimeProvider.GetEgyptDateTime();
        public double Money { get; set; }
        public string Comment { get; set; }

        public string CreatedBy { get; set; }

        [ForeignKey(nameof(User_Id))]
        public User User { get; set; }
    }
}
