using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Stocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.Stocks
{
    public class StocksRepository : GenericRepository<Stock>, IStocksRepository
    {
        public StocksRepository(DB context)
    : base(context)
        {
        }
    }
}
