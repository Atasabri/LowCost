using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Brands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.Brands
{
    public class BrandsRepository : GenericRepository<Brand>, IBrandsRepository
    {
        public BrandsRepository(DB context)
            : base(context)
        {
        }
    }
}
