using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class Favorites : BaseModel
    {
        [Required]
        public string User_Id { get; set; }
        [Required]
        public int Product_Id { get; set; }


        [ForeignKey(nameof(User_Id))]
        public User User { get; set; }

        [ForeignKey(nameof(Product_Id))]
        public Product Product { get; set; }
    }
}
