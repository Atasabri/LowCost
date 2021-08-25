using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Domain.Models
{
    public class PromoCode : BaseModel
    {
        [Required]
        public string Code { get; set; }
        [Required]
        public double DiscountPercent { get; set; }
    }
}
