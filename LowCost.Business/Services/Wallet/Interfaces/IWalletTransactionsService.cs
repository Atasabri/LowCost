using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using LowCost.Infrastructure.DTOs.Wallet;
using LowCost.Infrastructure.Helpers;

namespace LowCost.Business.Services.Wallet.Interfaces
{
    public interface IWalletTransactionsService
    {
        /// <summary>
        /// Get Current User Wallet Balance Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<double> GetBalanceAsync();
        /// <summary>
        /// Adding New Wallet Pull Transaction Asynchronous
        /// </summary>
        /// <param name="addTransactionDTO"></param>
        /// <returns></returns>
        Task<CreateState> AddPullTransactionAsync(AddTransactionDTO addTransactionDTO);
    }
}
