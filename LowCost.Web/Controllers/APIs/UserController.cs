using LowCost.Business.Services.User.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DTOs.User;
using LowCost.Infrastructure.Helpers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.APIs
{
    public class UserController : AuthorizedAPIController
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            this._userService = userService;
        }

        [AllowAnonymous]
        [HttpPut("ResetPassword")]
        public async Task<IActionResult> ResetPassword([FromBody] ResetPasswordDTO resetPasswordDTO)
        {
            var result = await _userService.ResetPasswordAsync(resetPasswordDTO);
            if (result.ExcuteSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("EditProfile")]
        public async Task<IActionResult> EditProfile([FromForm] EditProfileDTO editProfileDTO)
        {
            var result = await _userService.EditProfileAsync(editProfileDTO);
            if (result.ExcuteSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("ChangeUserCurrentLanguage/{lang}")]
        public async Task<IActionResult> ChangeUserCurrentLanguage(Languages lang)
        {
            var result = await _userService.ChangeLoginedUserCurrentLanguageAsync(lang);
            if (result.ExcuteSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet("Profile")]
        public async Task<IActionResult> Profile()
        {
            return Ok(await _userService.ProfileAsync());
        }

        [HttpPut("EditPassword")]
        public async Task<IActionResult> EditPassword([FromBody] ChangePasswordDTO changePasswordDTO)
        {
            var result = await _userService.ChangePasswordAsync(changePasswordDTO);
            if (result.ExcuteSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPut("ChangeCurrentUserZone/{zoneId}")]
        public async Task<IActionResult> ChangeCurrentUserZone(int zoneId)
        {
            var result = await _userService.ChangeCurrentUserZoneAsync(zoneId);
            if (result.ExcuteSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
