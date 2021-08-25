using LowCost.Business.Services.Identity.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DTOs.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.APIs
{
    public class AuthController : APIController
    {
        private readonly IAuthenticationService _authenticationService;
        private readonly IDriverAuthenticationService _driverAuthenticationService;

        public AuthController(IAuthenticationService authenticationService, IDriverAuthenticationService driverAuthenticationService)
        {
            this._authenticationService = authenticationService;
            this._driverAuthenticationService = driverAuthenticationService;
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginDTO loginDTO)
        {
            var result = await _authenticationService.LoginAsync(loginDTO);
            if (result.LoginSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("Register")]
        public async Task<IActionResult> Register([FromBody] RegisterDTO registerDTO)
        {
            var result = await _authenticationService.RegisterAsync(registerDTO);
            if (result.RegisterSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("ExternalLogin")]
        public async Task<IActionResult> ExternalLogin([FromBody] ExternalLoginDTO externalLoginDTO)
        {
            var result = await _authenticationService.ExternalLoginAsync(externalLoginDTO);
            if (result.LoginSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost("DriverLogin")]
        public async Task<IActionResult> DriverLogin([FromBody] LoginDTO loginDTO)
        {
            var result = await _driverAuthenticationService.LoginAsync(loginDTO);
            if (result.LoginSuccessfully)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
