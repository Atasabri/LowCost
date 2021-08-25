using LowCost.Infrastructure.DTOs.User.Address;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.User.Interfaces
{
    public interface IAddressService
    {
        /// <summary>
        /// Adding New Address to Current Logined User Asynchronous
        /// </summary>
        /// <param name="addAddressDTO"></param>
        /// <returns></returns>
        Task<CreateState> AddAddressAsync(AddAddressDTO addAddressDTO);
        /// <summary>
        /// Delete Address Using Address Id Asynchronous
        /// </summary>
        /// <param name="deleteAddressDTO"></param>
        /// <returns></returns>
        Task<ActionState> RemoveAddressAsync(DeleteAddressDTO deleteAddressDTO);
        /// <summary>
        /// Get Current Logined User Addresses (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<AddressDTO>> GetUserAddressesAsync(PagingParameters pagingParameters);
    }
}
