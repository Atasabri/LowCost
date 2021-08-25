using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Statuses;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void DashboardStatusesMapping()
        {
            CreateMap<Statuses, StatusViewModel>().ReverseMap();
            CreateMap<AddStatusViewModel, Statuses>().ReverseMap();
            CreateMap<EditStatusViewModel, Statuses>().ReverseMap();
        }
    }
}
