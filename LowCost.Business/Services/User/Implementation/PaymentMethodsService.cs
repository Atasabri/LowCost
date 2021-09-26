using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.User.Interfaces;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DTOs.User.PaymentMethods;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using LowCost.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.User.Implementation
{
    public class PaymentMethodsService : IPaymentMethodsService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public PaymentMethodsService(IMapper mapper, IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> stringLocalizer)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._stringLocalizer = stringLocalizer;
        }
        public async Task<CreateState> AddPaymentMethodAsync(AddPaymentMethodDTO addPaymentMethodDTO)
        {
            var createState = new CreateState();
            // Get Current Logined User
            var userId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();
            addPaymentMethodDTO.User_Id = userId;
            // Payment Method DTO Mapping
            var paymentMethod = _mapper.Map<AddPaymentMethodDTO, PaymentMethod>(addPaymentMethodDTO);
            // Adding Payment Method To DB
            await _unitOfWork.PaymentMethodsRepository.CreateAsync(paymentMethod);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                createState.Id = paymentMethod.Id;
            }
            else
            {
                createState.ErrorMessages.Add(_stringLocalizer["Error in Adding This Payment Method !"]);
            }

            return createState;
        }

        public async Task<PagedResult<PaymentMethodDTO>> GetUserPaymentMethodsAsync(PagingParameters pagingParameters)
        {
            // Get Current Logined User
            var userId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();
            // Get Current User Payment Methods
            var paymentMethods = await _unitOfWork.PaymentMethodsRepository.GetElementsWithOrderAsync(paymentMethod => paymentMethod.User_Id == userId,
                pagingParameters, paymentMethod => paymentMethod.Id, OrderingType.Descending);
            // Payment Methods Mapping
            var addressesDTOs = paymentMethods.ToMappedPagedResult<PaymentMethod, PaymentMethodDTO>(_mapper);

            return addressesDTOs;
        }

        public async Task<ActionState> RemovePaymentMethodAsync(DeletePaymentMethodDTO deletePaymentMethodDTO)
        {
            var actionState = new ActionState();
            // Get Current Logined User
            var userId = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();
            // Get Payment Method Using Payment Method Id
            var paymentMethod = await _unitOfWork.PaymentMethodsRepository.FindElementAsync(paymentMethod => 
                                      paymentMethod.Id == deletePaymentMethodDTO.Id &&
                                      paymentMethod.User_Id == userId);
             
            if (paymentMethod != null)
            {
                // Deleting Payment Method
                _unitOfWork.PaymentMethodsRepository.Delete(paymentMethod);
                var result = await _unitOfWork.SaveAsync() > 0;
                if (result)
                {
                    actionState.ExcuteSuccessfully = true;
                }
                else
                {
                    actionState.ErrorMessages.Add(_stringLocalizer["Error In Delete This Payment Method"]);
                }
            }
            else
            {
                actionState.ErrorMessages.Add(_stringLocalizer["Can Not Find This Payment Method"]);
            }

            return actionState;
        }
    }
}
