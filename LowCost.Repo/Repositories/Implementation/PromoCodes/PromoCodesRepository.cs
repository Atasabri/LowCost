using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.PromoCodes;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.PromoCodes
{
    public class PromoCodesRepository : GenericRepository<PromoCode>, IPromoCodesRepository
    {
        public PromoCodesRepository(DB context)
            : base(context)
        {
        }
    }
}
