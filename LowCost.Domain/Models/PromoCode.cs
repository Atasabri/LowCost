using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class PromoCode : BaseModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public double DiscountPercent { get; set; }

        public bool FreeDelivery { get; set; }
        public int? Category_Id { get; set; }
        public int? SubCategory_Id { get; set; }
        public int? Zone_Id { get; set; }


        [ForeignKey(nameof(Category_Id))]
        public Category Category { get; set; }
        [ForeignKey(nameof(SubCategory_Id))]
        public SubCategory SubCategory { get; set; }
        [ForeignKey(nameof(Zone_Id))]
        public Zone Zone { get; set; }
    }
}
