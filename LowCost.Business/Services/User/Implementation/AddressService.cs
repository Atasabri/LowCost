using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.User.Interfaces;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DTOs.User.Address;
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
    public class AddressService : IAddressService
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public AddressService(IMapper mapper, IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> stringLocalizer)
        {
            this._mapper = mapper;
            this._unitOfWork = unitOfWork;
            this._stringLocalizer = stringLocalizer;
        }

        public async Task<CreateState> AddAddressAsync(AddAddressDTO addAddressDTO)
        {
            var createState = new CreateState();
            // Get Current Logined User
            var userId = await _unitOfWork.UsersRepository.GetCurrentUserId();
            addAddressDTO.User_Id = userId;
            // Address DTO Mapping
            var address = _mapper.Map<AddAddressDTO, Address>(addAddressDTO);
            // Adding Address To DB
            await _unitOfWork.AddressesRepository.CreateAsync(address);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                createState.Id = address.Id;
            }
            else
            {
                createState.ErrorMessages.Add(_stringLocalizer["Error in Adding This Address !"]);
            }

            return createState;
        }

        public async Task<PagedResult<AddressDTO>> GetUserAddressesAsync(PagingParameters pagingParameters)
        {
            // Get Current Logined User
            var userId = await _unitOfWork.UsersRepository.GetCurrentUserId();
            // Get Current User Addresses
            var addresses = await _unitOfWork.AddressesRepository.GetElementsWithOrderAsync(address => address.User_Id == userId,
                pagingParameters, address => address.Id, OrderingType.Descending);
            // Addresses Mapping
            var addressesDTOs = addresses.ToMappedPagedResult<Address, AddressDTO>(_mapper);

            return addressesDTOs;
        }

        public async Task<ActionState> RemoveAddressAsync(DeleteAddressDTO deleteAddressDTO)
        {
            var actionState = new ActionState();
            // Get Current Logined User
            var userId = await _unitOfWork.UsersRepository.GetCurrentUserId();
            // Get Address Using Address Id
            var address = await _unitOfWork.AddressesRepository.FindElementAsync(address => 
                                address.Id == deleteAddressDTO.Address_Id &&
                                address.User_Id == userId);

            if(address != null)
            {
                // Deleting Address
                 _unitOfWork.AddressesRepository.Delete(address);
                var result = await _unitOfWork.SaveAsync() > 0;
                if(result)
                {
                    actionState.ExcuteSuccessfully = true;
                }
                else
                {
                    actionState.ErrorMessages.Add(_stringLocalizer["Error In Delete This Address"]);
                }
            }
            else
            {
                actionState.ErrorMessages.Add(_stringLocalizer["Can Not Find This Address"]);
            }

            return actionState;
        }
    }
}
