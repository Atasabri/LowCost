using LowCost.Domain.Models.BaseModels;
using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace LowCost.Domain.Models
{
    public class Order : BaseModel
    {
        [Required]
        public DateTime DateTime { get; set; }
        [Required]
        public bool Paid { get; set; }
        [Required]
        public bool Closed { get; set; }
        [Required]
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Delivery { get; set; }
        public double TotalSize { get; set; }
        public PaymentWays PaymentWay { get; set; } 
        [Required]
        public double Total { get; set; }

        [Required]
        public string User_Id { get; set; }

        public int Zone_Id { get; set; }
        public int Stock_Id { get; set; }

        public string Driver_Id { get; set; }

        public string Street { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Apartment { get; set; }
        [Required]
        public string Phone { get; set; }
        public string Discription { get; set; }

        public bool Started { get; set; }
        public bool Finished { get; set; }
        public DateTime? Start_Date { get; set; }
        public DateTime? Finish_Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }


        [ForeignKey(nameof(User_Id))]
        public User User { get; set; }

        [ForeignKey(nameof(Driver_Id))]
        public User Driver { get; set; }



        public virtual ICollection<OrderDetails> OrderDetails { get; set; }

        public virtual ICollection<OrderStatus> OrderStatuses { get; set; }

        public virtual ICollection<Notification> Notifications { get; set; }
    }
}
