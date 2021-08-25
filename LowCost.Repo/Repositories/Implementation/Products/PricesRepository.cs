using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Products;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.Products
{
    public class PricesRepository : GenericRepository<Prices>, IPricesRepository
    {
        public PricesRepository(DB context)
            : base(context)
        {
        }
    }
}
