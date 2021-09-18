using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.OrderSizeDelivery;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void DashboardOrderSizeDeliveryMapping()
        {
            CreateMap<OrderSizeDelivery, OrderSizeDeliveryViewModel>()
                .ReverseMap();

            CreateMap<OrderSizeDelivery, AddOrderSizeDeliveryViewModel>()
                .ReverseMap();

            CreateMap<OrderSizeDelivery, EditOrderSizeDeliveryViewModel>()
                .ReverseMap();
        }
    }
 }
