using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LowCost.Business.Services.Wallet.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DTOs.Wallet;

namespace LowCost.Web.Controllers.APIs
{
    public class WalletController : AuthorizedAPIController
    {
        private readonly IWalletTransactionsService _walletTransactionsService;

        public WalletController(IWalletTransactionsService walletTransactionsService)
        {
            this._walletTransactionsService = walletTransactionsService;
        }

        [HttpGet("GetBalance")]
        public async Task<IActionResult> GetBalance()
        {
            return Ok(await _walletTransactionsService.GetBalanceAsync());
        }

        [HttpPost("AddPullTransaction")]
        public async Task<IActionResult> AddPullTransaction([FromBody] AddTransactionDTO addTransactionDTO)
        {
            var result = await _walletTransactionsService.AddPullTransactionAsync(addTransactionDTO);
            if (result.CreatedSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
