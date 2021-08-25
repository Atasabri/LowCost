using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Notifications.Interfaces;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DTOs.Notifications;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Notifications.Implementation
{
    public class NotificationsService : INotificationsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public NotificationsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<PagedResult<NotificationDTO>> GetUserNotificationsAsync(PagingParameters pagingParameters)
        {
            var userId = await _unitOfWork.UsersRepository.GetCurrentUserId();
            
            var notifications = await _unitOfWork.NotificationsRepository.GetElementsWithOrderAsync(notification => notification.User_Id == userId,
                pagingParameters,
                notification => notification.DateTime, OrderingType.Descending);

            var notificationsDTOs = notifications.ToMappedPagedResult<Notification, NotificationDTO>(_mapper);

            return notificationsDTOs;
        }
    }
}
