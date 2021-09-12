using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Orders
{
    public class OrderViewModel : BaseViewModel
    {
        [Display(Name = "Date Time")]
        public DateTime DateTime { get; set; }
        public bool Paid { get; set; }
        public bool Closed { get; set; }
        [Display(Name = "Sub Total")]
        public double SubTotal { get; set; }
        public double Discount { get; set; }
        public double Taxs { get; set; }
        [Display(Name = "Payment Way")]
        public PaymentWays PaymentWay { get; set; }
        public double Total { get; set; }
        public int Zoon_Id { get; set; }

        public string User_Id { get; set; }
        [Display(Name = "User Name")]
        public string UserName { get; set; }
        public string Driver_Id { get; set; }
        [Display(Name = "Driver Name")]
        public string DriverName { get; set; }
        [Display(Name = "Driver Phone")]
        public string DriverPhone { get; set; }
        [Display(Name = "User Phone")]
        public string UserPhone { get; set; }
        [Display(Name = "User Email")]
        public string UserEmail { get; set; }

        public string Street { get; set; }
        public string Building { get; set; }
        public string Floor { get; set; }
        public string Apartment { get; set; }
        public string Phone { get; set; }
        public string Discription { get; set; }

        public bool Started { get; set; }
        public bool Finished { get; set; }
        [Display(Name = "Start Date")]
        public DateTime? Start_Date { get; set; }
        [Display(Name = "Finish Date")]
        public DateTime? Finish_Date { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public IEnumerable<OrderDetailsViewModel> OrderDetails { get; set; }

        public IEnumerable<OrderStatusesViewModel> OrderStatuses { get; set; }
    }
}
