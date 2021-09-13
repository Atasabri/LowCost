using LowCost.Infrastructure.DTOs.Products;
using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Orders
{
    public class OrderDTO : BaseDTO
    {
        public DateTime DateTime { get; set; }
        public bool Paid { get; set; }
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Taxs { get; set; }
        public PaymentWays PaymentWay { get; set; }
        public double Total { get; set; }

        public string Street { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Apartment { get; set; }
        public string Phone { get; set; }
        public string Discription { get; set; }

        public bool Started { get; set; }
        public bool Finished { get; set; }
        public bool Closed { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? Finish_Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }

        public string UserName { get; set; }
        public string Zone_Id { get; set; }

        public string DriverName { get; set; }
        public string DriverPhone { get; set; }

        public List<OrderStatusDTO> OrderStatuses { get; set; }
        public List<OrderDetailsDTO> OrderDetails { get; set; }

        public int ProductCount
        {
            get
            {
                return OrderDetails.Count;
            }
        }
    }
}
