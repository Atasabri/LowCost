using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using LowCost.Infrastructure.DashboardViewModels.Products.Prices;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Products
{
    public class EditProductViewModel : BaseNamedViewModel
    {
        [Required]
        [Display(Name = "Sub Category")]
        public int SubCategory_Id { get; set; }
        [Required]
        [Display(Name = "Brand")]
        public int Brand_Id { get; set; }

        [Display(Name = "Serial Number")]
        public string Serial_Number { get; set; }
        [Required]
        public double Size { get; set; }

        private int? offerid;
        [Display(Name = "Offer")]
        public int? Offer_Id
        {
            get { return offerid; }
            set
            {
                offerid = value == 0 ? null : value;
            }
        }

        public List<AddPriceViewModel> AddingPrices { get; set; } = new List<AddPriceViewModel>();
        public List<ProductStockQuantityViewModel> StockQuantities { get; set; } = new List<ProductStockQuantityViewModel>();
        public int[] DeletingPrices { get; set; } = new int[] { };

        public IFormFile Photo { get; set; }
    }
}
