using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;
using System.Text.Json.Serialization;

namespace LowCost.Infrastructure.DTOs.User.Address
{
    public class AddAddressDTO 
    {
        public string Street { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Apartment { get; set; }
        public string Phone { get; set; }
        public string Discription { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        [JsonIgnore]
        public string User_Id { get; set; }

    }
}
