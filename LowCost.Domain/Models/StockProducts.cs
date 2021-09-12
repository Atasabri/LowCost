using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class StockProducts : BaseModel
    {
        [Range(0, int.MaxValue)]
        public int Quantity { get; set; }


        public int Stock_Id { get; set; }
        public int Product_Id { get; set; }


        [ForeignKey(nameof(Product_Id))]
        public Product Product { get; set; }

        [ForeignKey(nameof(Stock_Id))]
        public Stock Stock { get; set; }

    }
}
