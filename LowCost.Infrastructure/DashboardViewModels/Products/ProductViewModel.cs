using LowCost.Infrastructure.DashboardViewModels.BaseViewModels;
using LowCost.Infrastructure.DashboardViewModels.Products.Prices;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace LowCost.Infrastructure.DashboardViewModels.Products
{
    public class ProductViewModel : ListingProductViewModel
    {
        [Display(Name = "Offer Name")]
        public string OfferName { get; set; }
        [Display(Name = "Serial Number")]
        public string Serial_Number { get; set; }

        [Display(Name = "Offer")]
        public int? Offer_Id { get; set; }
        public List<PriceViewModel> Prices { get; set; }
        public List<ProductStockQuantityViewModel> StockQuantities { get; set; } = new List<ProductStockQuantityViewModel>();
    }
}
