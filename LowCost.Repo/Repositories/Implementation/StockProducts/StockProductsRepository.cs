using LowCost.Domain.Context;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.StockProducts;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.StockProducts
{
    public class StockProductsRepository : GenericRepository<Domain.Models.StockProducts>, IStockProductsRepository
    {
        public StockProductsRepository(DB context)
    : base(context)
        {
        }
    }
}
