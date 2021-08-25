using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Markets;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.Markets
{
    public class MarketsRepository : GenericRepository<Market>, IMarketsRepository
    {
        public MarketsRepository(DB context)
            : base(context)
        {
        }
    }
}
