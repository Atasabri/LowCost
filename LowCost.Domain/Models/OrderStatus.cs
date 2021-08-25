using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class OrderStatus : BaseModel
    {
        [Required]
        public DateTime DateTime { get; set; }


        [Required]
        public int Order_Id { get; set; }
        [Required]
        public int Status_Id { get; set; }



        [ForeignKey(nameof(Order_Id))]
        public Order Order { get; set; }

        [ForeignKey(nameof(Status_Id))]
        public Statuses Status { get; set; }
    }
}
