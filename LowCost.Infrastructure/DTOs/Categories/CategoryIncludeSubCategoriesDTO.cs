using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Infrastructure.DTOs.Categories
{
    public class CategoryIncludeSubCategoriesDTO : CategoryDTO
    {
        public IEnumerable<SubCategoryDTO> SubCategories { get; set; }
    }
}
