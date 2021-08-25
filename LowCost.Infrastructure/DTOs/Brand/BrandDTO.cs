using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Brand
{
    public class BrandDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Image
        {
            get
            {
                return "/Uploads/Brands/" + Id + ".jpg?q=" + DateTime.Now.ToBinary();
            }
        }
    }
}
