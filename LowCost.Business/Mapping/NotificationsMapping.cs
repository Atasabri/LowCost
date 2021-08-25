using AutoMapper;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DTOs.Notifications;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        void NotificationsMapping()
        {
            CreateMap<Notification, NotificationDTO>().ReverseMap();
        }
    }
}
