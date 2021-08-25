using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class MainCategory : BaseNamedModel
    {
        public virtual ICollection<Category>  Categories { get; set; }
    }
}
