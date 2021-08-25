using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Domain.Models.BaseModels
{
    public class BaseNamedModel : BaseModel
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public string Name_AR { get; set; }
    }
}
