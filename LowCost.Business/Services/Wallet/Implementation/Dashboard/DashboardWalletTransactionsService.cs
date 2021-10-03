using AutoMapper;
using LowCost.Business.Services.Wallet.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.Wallet;
using LowCost.Infrastructure.Helpers;
using LowCost.Repo.UnitOfWork;
using LowCost.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xedge.Infrastructure.Helpers;

namespace LowCost.Business.Services.Wallet.Implementation.Dashboard
{
    public class DashboardWalletTransactionsService : IDashboardWalletTransactionsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly IMapper _mapper;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public DashboardWalletTransactionsService(IUnitOfWork unitOfWork, UserManager<Domain.Models.User> userManager, IMapper mapper, IStringLocalizer<SharedResource> stringLocalizer)
        {
            this._unitOfWork = unitOfWork;
            this._userManager = userManager;
            this._mapper = mapper;
            this._stringLocalizer = stringLocalizer;
        }

        public async Task<CreateState> AddDepositTransactionAsync(AddTransactionViewModel addTransactionViewModel)
        {
            var createState = new CreateState();
            var admin = await _unitOfWork.CurrentUserRepository.GetCurrentUser();
            var walletTransaction = _mapper.Map<AddTransactionViewModel, Domain.Models.WalletTransaction>(addTransactionViewModel);
            walletTransaction.TransactionType = TransactionTypes.Deposit;
            walletTransaction.CreatedBy = admin.UserName;
            var user = await _userManager.FindByIdAsync(addTransactionViewModel.UserId);
            user.Balance += addTransactionViewModel.Money;
            walletTransaction.User_Id = addTransactionViewModel.UserId;


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
