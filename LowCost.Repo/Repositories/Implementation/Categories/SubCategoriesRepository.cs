using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.Categories
{
    public class SubCategoriesRepository : GenericRepository<SubCategory>, ISubCategoriesRepository
    {
        public SubCategoriesRepository(DB context)
            : base(context)
        {
        }
    }
}
