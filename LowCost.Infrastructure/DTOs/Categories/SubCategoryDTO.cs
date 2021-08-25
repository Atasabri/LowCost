using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Categories
{
    public class SubCategoryDTO : BaseDTO
    {
        public string Name { get; set; }

        public string Image
        {
            get
            {
                return "/Uploads/SubCategories/" + Id + ".jpg?q=" + DateTime.Now.ToBinary();
            }
        }
    }
}
