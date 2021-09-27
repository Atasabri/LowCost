using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class Prices : BaseModel
    {
        [Required]
        public double Price { get; set; }
        public double? OldPrice { get; set; }
        public int? MaxQuantityPerOrder { get; set; }
        [Required]
        public int Product_Id { get; set; }
        [Required]
        public int Market_Id { get; set; }



        [ForeignKey(nameof(Product_Id))]
        public Product Product { get; set; }

        [ForeignKey(nameof(Market_Id))]
        public Market Market { get; set; }
    }
}
