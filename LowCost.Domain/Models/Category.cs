using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class Category : BaseNamedModel
    {
        [Required]
        public int MainCategory_Id { get; set; }
        [Required]
        public int OrderKey { get; set; }
        [Required]
        public bool ViewInApp { get; set; }

        [ForeignKey(nameof(MainCategory_Id))]
        public MainCategory MainCategory { get; set; }

        public virtual ICollection<SubCategory> SubCategories { get; set; }
    }
}
