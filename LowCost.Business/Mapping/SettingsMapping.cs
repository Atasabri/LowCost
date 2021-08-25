using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Settings;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {

        void DashboardSettingsMapping()
        {
            CreateMap<Settings, SettingsKeyValueViewModel>().ReverseMap();
        }
    }
}
