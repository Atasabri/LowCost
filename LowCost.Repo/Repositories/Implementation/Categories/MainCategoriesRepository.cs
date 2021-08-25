using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Categories;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.Categories
{
    public class MainCategoriesRepository : GenericRepository<MainCategory>, IMainCategoriesRepository
    {
        public MainCategoriesRepository(DB context)
            : base(context)
        {
        }
    }
}
