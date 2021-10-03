using AutoMapper;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LowCost.Business.Services.Wallet.Interfaces;
using LowCost.Infrastructure.DTOs.Wallet;
using LowCost.Infrastructure.Helpers;
using LowCost.Repo.UnitOfWork;
using LowCost.Resources;
using Xedge.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;

namespace LowCost.Business.Services.Wallet.Implementation
{
    public class WalletTransactionsService : IWalletTransactionsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public WalletTransactionsService(IUnitOfWork unitOfWork, UserManager<Domain.Models.User> userManager, IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer)
        {
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
            this._mapper = mapper;
            this._stringLocalizer = stringLocalizer;
        }

        public async Task<double> GetBalanceAsync()
        {
            var user = await _unitOfWork.CurrentUserRepository.GetCurrentUser();
            var balance = user.Balance;

            return balance;
        }

        public async Task<CreateState> AddPullTransactionAsync(AddTransactionDTO addTransactionDTO)
        {
            var createState = new CreateState();
            var user = await _unitOfWork.CurrentUserRepository.GetCurrentUser();
            var walletTransaction = _mapper.Map<AddTransactionDTO, Domain.Models.WalletTransaction>(addTransactionDTO);
            walletTransaction.User_Id = user.Id;
            walletTransaction.TransactionType = TransactionTypes.Pull;
            user.Balance -= addTransactionDTO.Money;

            await _unitOfWork.WalletTransactionsRepository.CreateAsync(walletTransaction);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                await _userManager.UpdateAsync(user);
                createState.CreatedSuccessfully = true;
                createState.Id = walletTransaction.Id;
                return createState;
            }
            createState.ErrorMessages.Add(_stringLocalizer["Can Not Complete Transaction"]);
            return createState;
        }
    }
}
