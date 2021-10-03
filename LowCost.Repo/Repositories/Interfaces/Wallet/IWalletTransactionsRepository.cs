using System;
using System.Collections.Generic;
using System.Text;
using LowCost.Domain.Models;
using LowCost.Repo.Generic;

namespace LowCost.Repo.Repositories.Interfaces.Wallet
{
    public interface IWalletTransactionsRepository : IGenericRepository<WalletTransaction>
    {
    }
}
