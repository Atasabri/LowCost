using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Repo.Repositories.Implementation.User
{
    public class PaymentMethodsRepository : GenericRepository<PaymentMethod>, IPaymentMethodsRepository
    {
        public PaymentMethodsRepository(DB context)
            : base(context)
        {
        }
    }
}
