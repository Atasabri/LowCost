using AutoMapper;
using LowCost.Business.Helpers;
using LowCost.Business.Helpers.NotificationHelpers;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Orders.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Orders;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.NotificationsHelpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using LowCost.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Orders.Implementation.Dashboard
{
    public class DashboardOrdersService : IDashboardOrdersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly OrderNotificationHandler _orderNotificationHandler;
        private readonly UserManager<Domain.Models.User> _userManager;
        Domain.Models.User currentAdmin = null;

        public DashboardOrdersService(IUnitOfWork unitOfWork, UserManager<Domain.Models.User> userManager,
            IMapper mapper, OrderNotificationHandler orderNotificationHandler)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._orderNotificationHandler = orderNotificationHandler;
            this._userManager = userManager;
            currentAdmin = _unitOfWork.UsersRepository.GetCurrentDashboardAdminUser().Result;
        }
        public async Task<CreateState> AddOrderStatusAsync(AddOrderStatusViewModel addStatusViewModel)
        {
            var createState = new CreateState();
            var order = await _unitOfWork.OrdersRepository.FindByIdAsync(addStatusViewModel.Order_Id);
            if(order.Closed)
            {
                createState.ErrorMessages.Add("Order Is Closed");
                return createState;
            }
            if(currentAdmin.Stock_Id != null && order.Stock_Id != currentAdmin.Stock_Id)
            {
                createState.ErrorMessages.Add("You Can Not Change in Order Out Of Your Stock");
                return createState;
            }
            var orderStatus = _mapper.Map<AddOrderStatusViewModel, OrderStatus>(addStatusViewModel);
            // Check If Status Added Before For This Order
            var statusAddedBefore = await _unitOfWork.OrderStatusesRepository
                .CheckOrderStatusAddedBeforeAsync(addStatusViewModel.Order_Id,
                addStatusViewModel.Status_Id);

            if(statusAddedBefore)
            {
                createState.ErrorMessages.Add("This Status Added Before For This Order");
                return createState;
            }
            await _unitOfWork.OrderStatusesRepository.CreateAsync(orderStatus);
            var result = await _unitOfWork.SaveAsync() > 0;
            if(result)
            {
                await _orderNotificationHandler.ChangeStatusNotify(orderStatus.Order_Id);
                createState.CreatedSuccessfully = true;
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Add Order Status");
            return createState;
        }

        public async Task<ActionState> CloseOrderAsync(int id)
        {
            var actionState = new ActionState();
            var order = await _unitOfWork.OrdersRepository.FindByIdAsync(id);
            if (currentAdmin.Stock_Id != null && order.Stock_Id != currentAdmin.Stock_Id)
            {
                actionState.ErrorMessages.Add("You Can Not Close Order Out Of Your Stock");
                return actionState;
            }
            if (order.Closed)
            {
                actionState.ErrorMessages.Add("This Order Is Already Closed");
                return actionState;
            }
            order.Closed = true;
            _unitOfWork.OrdersRepository.Update(order);
            var result = await _unitOfWork.SaveAsync() > 0;
            if(result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Close This Order");
            return actionState;
        }

        public async Task<IEnumerable<StatusesViewModel>> GetAllStatusesAsync()
        {
            var statuses = await _unitOfWork.StatusesRepository.GetElementsAsync(status => true);

            var statusesViewModel = _mapper.Map<IEnumerable<LowCost.Domain.Models.Statuses>, IEnumerable<StatusesViewModel>>(statuses);
            return statusesViewModel;
        }

        public async Task<OrderViewModel> GetOrderDetailsAsync(int id)
        {
            var currentAdmin = await _unitOfWork.UsersRepository.GetCurrentDashboardAdminUser();
            var order = await _unitOfWork.OrdersRepository.FindElementAsync(order => order.Id == id && (currentAdmin.Stock_Id == null || order.Stock_Id == currentAdmin.Stock_Id),
                string.Format("{0}.{1},{2}.{3},{4}.{5},{6},{7}",
                nameof(Order.OrderDetails), nameof(OrderDetails.Product),
                nameof(Order.OrderDetails), nameof(OrderDetails.Market),
                nameof(Order.OrderStatuses), nameof(OrderStatus.Status),
                nameof(Order.User), nameof(Order.Driver)));

            var orderViewModel = _mapper.Map<Order, OrderViewModel>(order);
            return orderViewModel;
        }

        public async Task<PagedResult<ListingOrderViewModel>> GetOrdersAsync(PagingParameters pagingParameters)
        {
            var currentAdmin = await _unitOfWork.UsersRepository.GetCurrentDashboardAdminUser();
            var orders = await _unitOfWork.OrdersRepository.GetElementsWithOrderAsync(order => currentAdmin.Stock_Id == null || order.Stock_Id == currentAdmin.Stock_Id, pagingParameters,
                order => order.DateTime, OrderingType.Descending);

            var ordersViewModel = orders.ToMappedPagedResult<Order, ListingOrderViewModel>(_mapper);
            return ordersViewModel;
        }

        public async Task<IEnumerable<OrderStatusesViewModel>> GetOrderStatusesAsync(int id)
        {
            var statuses = await _unitOfWork.OrderStatusesRepository.GetElementsAsync(status => status.Order_Id == id, nameof(OrderStatus.Status));

            var statusesViewModel = _mapper.Map<IEnumerable<OrderStatus>, IEnumerable<OrderStatusesViewModel>>(statuses);
            return statusesViewModel;
        }

        public async Task<ActionState> AssignOrderDriverAsync(AddOrderDriverViewModel addOrderDriverViewModel)
        {
            var actionState = new ActionState();
            var order = await _unitOfWork.OrdersRepository.FindByIdAsync(addOrderDriverViewModel.Order_Id);
            if (order.Closed)
            {
                actionState.ErrorMessages.Add("Order Is Closed");
                return actionState;
            }
            if (currentAdmin.Stock_Id != null && order.Stock_Id != currentAdmin.Stock_Id)
            {
                actionState.ErrorMessages.Add("You Can Not Assign Driver to Order Out Of Your Stock");
                return actionState;
            }
            var driver = await _userManager.FindByIdAsync(addOrderDriverViewModel.Driver_Id);
            var isDriverInRoleDriver = await _userManager.IsInRoleAsync(driver, Constants.DriverRoleName);
            // Check If Driver Is in Role Driver And Work in Order Stock
            if (!isDriverInRoleDriver)
            {
                actionState.ErrorMessages.Add("Only Drivers Can Send Orders");
                return actionState;
            }
            if(driver.Stock_Id != order.Stock_Id)
            {
                actionState.ErrorMessages.Add("Driver Not Registered in Order Stock");
                return actionState;
            }
            order.Driver_Id = addOrderDriverViewModel.Driver_Id;
            _unitOfWork.OrdersRepository.Update(order);
            var result = await _unitOfWork.SaveAsync() > 0;
            if(result)
            {
                await _orderNotificationHandler.AssignDriverNotify(order.Id);
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Assign Driver to This Order");
            return actionState;
        }
    }
}
