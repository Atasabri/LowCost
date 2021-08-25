using LowCost.Business.Services.User.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DTOs.User.Address;
using LowCost.Infrastructure.Pagination;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.APIs
{
    public class AddressController : AuthorizedAPIController
    {
        private readonly IAddressService _addressService;

        public AddressController(IAddressService addressService)
        {
            this._addressService = addressService;
        }

        [HttpGet("GetAddresses")]
        public async Task<IActionResult> GetAddresses([FromQuery] PagingParameters pagingParameters)
        {
            return Ok(await _addressService.GetUserAddressesAsync(pagingParameters));
        }

        [HttpPost("AddAddress")]
        public async Task<IActionResult> AddAddress([FromBody] AddAddressDTO addAddressDTO)
        {
            var result = await _addressService.AddAddressAsync(addAddressDTO);
            if(result.CreatedSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpDelete("DeleteAddress")]
        public async Task<IActionResult> DeleteAddress([FromBody] DeleteAddressDTO deleteAddressDTO)
        {
            var result = await _addressService.RemoveAddressAsync(deleteAddressDTO);
            if (result.ExcuteSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
