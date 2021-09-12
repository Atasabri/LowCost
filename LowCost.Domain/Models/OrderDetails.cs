using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class OrderDetails : BaseModel
    {
        [Required]
        public double Price { get; set; }
        [Required]
        public int Quantity { get; set; }

        public double Size { get; set; }


        public int Product_Id { get; set; }
        public int Order_Id { get; set; }
        public int Market_Id { get; set; }



        [ForeignKey(nameof(Product_Id))]
        public Product Product { get; set; }

        [ForeignKey(nameof(Order_Id))]
        public Order Order { get; set; }

        [ForeignKey(nameof(Market_Id))]
        public Market Market { get; set; }
    }
}
