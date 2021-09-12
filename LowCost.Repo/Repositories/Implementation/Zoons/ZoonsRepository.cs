using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Zoons;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.Zoons
{
    public class ZoonsRepository : GenericRepository<Zoon>, IZoonsRepository
    {
        public ZoonsRepository(DB context)
             : base(context)
        {
        }
    }
}
