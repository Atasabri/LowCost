using LowCost.Infrastructure.DashboardViewModels.Wallet;
using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Wallet.Interfaces.Dashboard
{
    public interface IDashboardWalletTransactionsService
    {
        /// <summary>
        /// Adding New Wallet Deposit Transaction Asynchronous
        /// </summary>
        /// <param name="addTransactionViewModel"></param>
        /// <returns></returns>
        Task<CreateState> AddDepositTransactionAsync(AddTransactionViewModel addTransactionViewModel);
    }
}
