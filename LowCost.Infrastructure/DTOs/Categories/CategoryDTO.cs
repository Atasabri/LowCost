using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Categories
{
    public class CategoryDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Image
        {
            get
            {
                return "/Uploads/Categories/" + Id + ".jpg?q=" + DateTime.Now.ToBinary();
            }
        }
        public string Banner
        {
            get
            {
                return "/Uploads/Categories/Banners/" + Id + ".jpg?q=" + DateTime.Now.ToBinary();
            }
        }
    }
}
