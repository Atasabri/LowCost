using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class Market : BaseNamedModel
    {

        public virtual ICollection<Prices> Prices { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }
    }
}
