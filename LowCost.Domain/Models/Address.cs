using LowCost.Domain.Models.BaseModels;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class Address : BaseModel
    {
        public string Street { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Apartment { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Discription { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        [Required]
        public string User_Id { get; set; }


        [ForeignKey(nameof(User_Id))]
        public User User { get; set; }
    }
}
