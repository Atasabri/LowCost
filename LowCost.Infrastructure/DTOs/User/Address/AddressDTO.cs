using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.User.Address
{
    public class AddressDTO : BaseDTO
    {
        public string Street { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Apartment { get; set; }
        public string Phone { get; set; }
        public string Discription { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
    }
}
