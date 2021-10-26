using LowCost.Domain.Models.BaseModels;
using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Domain.Models
{
    public class Offer : BaseNamedModel
    {
        public bool IsNew { get; set; }
        public DateTime UpdatedDate { get; set; } = DateTimeProvider.GetEgyptDateTime();
        public virtual ICollection<Product> Products { get; set; }
    }
}
