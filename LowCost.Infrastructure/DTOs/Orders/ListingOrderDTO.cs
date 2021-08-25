using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace LowCost.Infrastructure.DTOs.Orders
{
    public class ListingOrderDTO : BaseDTO
    {
        public DateTime DateTime { get; set; }
        public double Total { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public bool Finished { get; set; }
        public bool Closed { get; set; }

        [JsonIgnore]
        public List<OrderStatusDTO> OrderStatuses { get; set; }
        public OrderStatusDTO Status
        {
            get
            {
                return OrderStatuses.OrderByDescending(status => status.DateTime).FirstOrDefault();
            }
        }

    }
}
