using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class PaymentMethod : BaseModel
    {

        public string CardHolderName { get; set; }
        public string CardNumber { get; set; }
        public string CardExpDate { get; set; }
        public string CVV { get; set; }


        [Required]
        public string User_Id { get; set; }



        [ForeignKey(nameof(User_Id))]
        public User User { get; set; }
    }
}
