using LowCost.Business.Helpers;
using LowCost.Business.Services.Identity.Interfaces;
using LowCost.Infrastructure.DTOs.Identity;
using LowCost.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Identity.Implementation
{
    public class DriverAuthenticationService : IDriverAuthenticationService
    {
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly SignInManager<Domain.Models.User> _signInManager;
        private readonly AuthenticationHandler _authenticationHandler;

        public DriverAuthenticationService(UserManager<Domain.Models.User> userManager,
            SignInManager<Domain.Models.User> signInManager, AuthenticationHandler authenticationHandler)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._authenticationHandler = authenticationHandler;
        }

        public async Task<LoginState> LoginAsync(LoginDTO loginDTO)
        {
            var loginState = new LoginState();

            var driver = await _userManager.FindByNameAsync(loginDTO.Email);

            // Check If Driver Found And in Drivers Role
            if (driver != null && await _userManager.IsInRoleAsync(driver, Constants.DriverRoleName))
            {
                var result = await _signInManager.CheckPasswordSignInAsync(driver, loginDTO.Password, false);

                if (result.Succeeded)
                {
                    var tokenJson = _authenticationHandler.CreateToken(driver, Constants.DriverRoleName);

                    await _authenticationHandler.ChangeUserFCMAsync(driver, loginDTO.FCM);

                    loginState.LoginSuccessfully = true;
                    loginState.Token = tokenJson;
                    loginState.User_Id = driver.Id;
                }
            }
            return loginState;
        }
    }
}
