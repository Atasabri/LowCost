using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Wallet;
using LowCost.Infrastructure.DTOs.Wallet;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void WalletMapping()
        {
            CreateMap<WalletTransaction, AddTransactionDTO>()
                   .ReverseMap();

        }

        void DashboardWalletMapping()
        {
            CreateMap<AddTransactionViewModel, WalletTransaction>()
             .ReverseMap();
        }
    }
}
