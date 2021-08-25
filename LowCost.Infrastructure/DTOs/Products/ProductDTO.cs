using LowCost.Infrastructure.DTOs.Brand;
using LowCost.Infrastructure.DTOs.Categories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace LowCost.Infrastructure.DTOs.Products
{
    public class ProductDTO : BaseDTO
    {
        public string Name { get; set; }
        public bool IsFav { get; set; }
        public SubCategoryDTO SubCategory { get; set; }
        public BrandDTO Brand { get; set; }
        public IEnumerable<PricesDTO> Prices { get; set; }
        public PricesDTO LowPriceData
        {
            get
            {
                return Prices.OrderBy(price => price.Price).FirstOrDefault();
            }
        }
        public string Image
        {
            get
            {
                return string.Format("/Uploads/Products/{0}.jpg?q={1}", this.Id, DateTime.Now.ToBinary());
            }
        }
    }
}
