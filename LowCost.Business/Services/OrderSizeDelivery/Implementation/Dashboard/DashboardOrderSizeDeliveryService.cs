using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.OrderSizeDelivery.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.OrderSizeDelivery;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.OrderSizeDelivery.Implementation.Dashboard
{
    public class DashboardOrderSizeDeliveryService : IDashboardOrderSizeDeliveryService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardOrderSizeDeliveryService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateOrderSizeDeliveryAsync(AddOrderSizeDeliveryViewModel addOrderSizeDeliveryViewModel)
        {
            var createState = new CreateState();
            var orderSizeDelivery = _mapper.Map<AddOrderSizeDeliveryViewModel, Domain.Models.OrderSizeDelivery>(addOrderSizeDeliveryViewModel);

            await _unitOfWork.OrderSizeDeliveryRepository.CreateAsync(orderSizeDelivery);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create Order Size Delivery Item");
            return createState;
        }

        public async Task<ActionState> DeleteOrderSizeDeliveryAsync(int id)
        {
            var actionState = new ActionState();
            var orderSizeDelivery = await _unitOfWork.OrderSizeDeliveryRepository.FindByIdAsync(id);
            if (orderSizeDelivery == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Order Size Delivery Item !");
                return actionState;
            }
            _unitOfWork.OrderSizeDeliveryRepository.Delete(orderSizeDelivery);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Order Size Delivery Item");
            return actionState;
        }

        public async Task<ActionState> EditOrderSizeDeliveryAsync(EditOrderSizeDeliveryViewModel editOrderSizeDeliveryViewModel)
        {
            var actionState = new ActionState();
            var orderSizeDelivery = _mapper.Map<EditOrderSizeDeliveryViewModel, Domain.Models.OrderSizeDelivery>(editOrderSizeDeliveryViewModel);
            _unitOfWork.OrderSizeDeliveryRepository.Update(orderSizeDelivery);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Order Size Delivery Item");
            return actionState;
        }

        public async Task<OrderSizeDeliveryViewModel> GetOrderSizeDeliveryDetailsAsync(int Id)
        {
            var orderSizeDelivery = await _unitOfWork.OrderSizeDeliveryRepository.FindByIdAsync(Id);

            var orderSizeDeliveryViewModel = _mapper.Map<Domain.Models.OrderSizeDelivery, OrderSizeDeliveryViewModel>(orderSizeDelivery);

            return orderSizeDeliveryViewModel;
        }

        public async Task<PagedResult<OrderSizeDeliveryViewModel>> GetDashboardOrderSizeDeliverysAsync(PagingParameters pagingParameters)
        {
            var orderSizeDeliveryItems = await _unitOfWork.OrderSizeDeliveryRepository.GetElementsWithOrderAsync(orderSizeDelivery => true,
                       pagingParameters, orderSizeDelivery => orderSizeDelivery.Id, OrderingType.Descending);

            var OrderSizeDeliveryItemsViewModel = orderSizeDeliveryItems.ToMappedPagedResult<Domain.Models.OrderSizeDelivery, OrderSizeDeliveryViewModel>(_mapper);

            return OrderSizeDeliveryItemsViewModel;
        }
    }
}
