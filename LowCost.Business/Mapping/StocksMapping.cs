using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Stocks;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void DashboardStocksMapping()
        {
            CreateMap<Stock, StockViewModel>().ReverseMap();
            CreateMap<AddStockViewModel, Stock>().ReverseMap();
            CreateMap<EditStockViewModel, Stock>().ReverseMap();
        }
    }
}
