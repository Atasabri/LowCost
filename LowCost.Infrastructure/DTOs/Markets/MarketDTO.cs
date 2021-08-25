using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Markets
{
    public class MarketDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Image
        {
            get
            {
                return "/Uploads/Markets/" + Id + ".jpg?q=" + DateTime.Now.ToBinary();
            }
        }
    }
}
