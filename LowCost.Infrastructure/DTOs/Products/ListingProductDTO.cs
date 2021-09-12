using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;

namespace LowCost.Infrastructure.DTOs.Products
{
    public class ListingProductDTO : BaseDTO
    {
        public string Name { get; set; }
        public int? Quantity { get; set; }
        public bool IsFav { get; set; }
        [JsonIgnore]
        public IEnumerable<PricesDTO> Prices { get; set; }
        [JsonIgnore]
        public IEnumerable<ProductStocksQuantityDTO> StockProducts { get; set; }

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
