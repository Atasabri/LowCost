using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Domain.Models
{
    public class Stock : BaseModel
    {
        public string Name { get; set; }


        public virtual ICollection<Zone> Zones { get; set; }

        public virtual ICollection<StockProducts> StockProducts { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
