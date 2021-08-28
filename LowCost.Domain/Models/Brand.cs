using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class Brand : BaseNamedModel
    {
        [Required]
        public int OrderKey { get; set; }
        [Required]
        public bool ViewInApp { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
}
