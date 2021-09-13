using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class Zone : BaseNamedModel
    {
        public int Stock_Id { get; set; }


        [ForeignKey(nameof(Stock_Id))]
        public Stock Stock { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
