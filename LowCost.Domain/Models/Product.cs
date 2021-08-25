using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class Product : BaseNamedModel
    {
        [Required]
        public int SubCategory_Id { get; set; }
        [Required]
        public int Brand_Id { get; set; }

        public string Serial_Number { get; set; }

        public int? Offer_Id { get; set; }



        [ForeignKey(nameof(SubCategory_Id))]
        public SubCategory SubCategory { get; set; }

        [ForeignKey(nameof(Brand_Id))]
        public Brand Brand { get; set; }

        [ForeignKey(nameof(Offer_Id))]
        public Offer Offer { get; set; }


        public virtual ICollection<Prices> Prices { get; set; }

        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual ICollection<Favorites> Favorites { get; set; }
    }
}
