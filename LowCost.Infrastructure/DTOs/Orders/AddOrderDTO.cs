using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace LowCost.Infrastructure.DTOs.Orders
{
    public class AddOrderDTO
    {
        [JsonIgnore]
        public DateTime DateTime { get; set; } = DateTimeProvider.GetEgyptDateTime();
        public bool Paid { get; set; }
        public PaymentWays PaymentWay { get; set; }

        public string Street { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Apartment { get; set; }
        public string Phone { get; set; }
        public string Discription { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public ICollection<AddOrderDetailsDTO>  OrderDetails { get; set; }
        [JsonIgnore]
        public string User_Id { get; set; }
        public int? Zoon_Id { get; set; }
        public string PromoCode { get; set; }
    }
}
