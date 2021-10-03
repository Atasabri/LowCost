using System;
using System.Collections.Generic;
using System.Text;
using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;
using LowCost.Repo.Repositories.Interfaces.Wallet;

namespace LowCost.Repo.Repositories.Implementation.Wallet
{
    public class WalletTransactionsRepository : GenericRepository<WalletTransaction>, IWalletTransactionsRepository
    {
        public WalletTransactionsRepository(DB context)
    : base(context)
        {
        }
    }
}
