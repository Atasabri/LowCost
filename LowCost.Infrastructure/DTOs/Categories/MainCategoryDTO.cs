using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Categories
{
    public class MainCategoryDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Image
        {
            get
            {
                return "/Uploads/MainCategories/" + Id + ".jpg?q=" + DateTime.Now.ToBinary();
            }
        }
    }
}
