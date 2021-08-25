using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Offers;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.Offers
{
    public class OffersRepository : GenericRepository<Offer>, IOffersRepository
    {
        public OffersRepository(DB context)
    : base(context)
        {
        }
    }
}
