using AutoMapper;
using LowCost.Business.Helpers;
using LowCost.Business.Services.Identity.Interfaces;
using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DTOs.Identity;
using LowCost.Infrastructure.Helpers;
using LowCost.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;


namespace LowCost.Business.Services.Identity.Implementation
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly SignInManager<Domain.Models.User> _signInManager;
        private readonly AuthenticationHandler _authenticationHandler;

        public AuthenticationService(UserManager<Domain.Models.User> userManager,
            SignInManager<Domain.Models.User> signInManager,
            AuthenticationHandler authenticationHandler)
        {
            this._userManager = userManager;
            this._signInManager = signInManager;
            this._authenticationHandler = authenticationHandler;
        }

        public async Task<LoginState> LoginAsync(LoginDTO loginDTO)
        {
            var loginState = new LoginState();

            var user = await _userManager.FindByNameAsync(loginDTO.Email);

            // Check If User Found And in Users Role
            if (user != null && await _userManager.IsInRoleAsync(user, Constants.UserRoleName))
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, loginDTO.Password, false);

                if (result.Succeeded)
                {
                    var tokenJson = _authenticationHandler.CreateToken(user, Constants.UserRoleName);

                    await _authenticationHandler.ChangeUserFCMAsync(user, loginDTO.FCM);

                    loginState.LoginSuccessfully = true;
                    loginState.Token = tokenJson;
                    loginState.User_Id = user.Id;
                }
            }
            return loginState;
        }
        public async Task<ExternalLoginState> ExternalLoginAsync(ExternalLoginDTO externalLoginDTO)
        {
            var loginState = new ExternalLoginState();

            var info = new UserLoginInfo(externalLoginDTO.ExternalLoginProvider.ToString(),
                externalLoginDTO.ExternalLoginId, externalLoginDTO.ExternalLoginProvider.ToString());

            var loginUser = await _userManager.FindByLoginAsync(info.LoginProvider, info.ProviderKey);

            if (loginUser == null)
            {
                var userName = externalLoginDTO.Email ?? externalLoginDTO.Phone ?? externalLoginDTO.FullName ?? externalLoginDTO.ExternalLoginId;
                // Check If User Have Login Before With Sending Email
                loginUser = await _userManager.FindByNameAsync(userName);
                if (loginUser == null)
                {
                    // Check Phone Is Available If External Login Have Phone
                    if (!string.IsNullOrEmpty(externalLoginDTO.Phone))
                    {
                        var checkPhoneResult = await _authenticationHandler.CheckPhoneNumberAvailableAsync(externalLoginDTO.Phone);
                        if (!checkPhoneResult.ExcuteSuccessfully)
                        {
                            loginState.ErrorMessages.AddRange(checkPhoneResult.ErrorMessages);
                            return loginState;
                        }
                    }

                    // Create New User And Assign Him to Users Role
                    loginUser = new Domain.Models.User()
                    {
                        Email = externalLoginDTO.Email,
                        UserName = userName,
                        FullName = externalLoginDTO.FullName,
                        FCM = externalLoginDTO.FCM,
                        Zoon_Id = externalLoginDTO.Zoon_Id,
                        PhoneNumber = externalLoginDTO.Phone
                    };
                    var createUserResult = await _userManager.CreateAsync(loginUser);
                    if(!createUserResult.Succeeded)
                    {
                        loginState.ErrorMessages.AddRange(createUserResult.Errors.Select(error => error.Description).ToList());
                        return loginState;
                    }
                    var addtoRoleResult = await _userManager.AddToRoleAsync(loginUser, Constants.UserRoleName);
                    if (!addtoRoleResult.Succeeded)
                    {
                        loginState.ErrorMessages.AddRange(addtoRoleResult.Errors.Select(error => error.Description).ToList());
                        return loginState;
                    }
                }
                // Adding Login Provider Data To User
                var addLoginResult = await _userManager.AddLoginAsync(loginUser, info);
                if(!addLoginResult.Succeeded)
                {
                    loginState.ErrorMessages.AddRange(addLoginResult.Errors.Select(error => error.Description).ToList());
                    return loginState;
                }
            }
            // Create JWT
            loginState.Token = _authenticationHandler.CreateToken(loginUser, Constants.UserRoleName);
            // Update FCM
            await _authenticationHandler.ChangeUserFCMAsync(loginUser, externalLoginDTO.FCM);
            loginState.LoginSuccessfully = true;
            loginState.User_Id = loginUser.Id;
            return loginState;
        }
        public async Task<RegisterState> RegisterAsync(RegisterDTO registerDTO)
        {
            var registerState = new RegisterState();
            var checkPhoneResult = await _authenticationHandler.CheckPhoneNumberAvailableAsync(registerDTO.Phone);
            if(!checkPhoneResult.ExcuteSuccessfully)
            {
                registerState.ErrorMessages.AddRange(checkPhoneResult.ErrorMessages);
                return registerState;
            }
            var user = new Domain.Models.User() 
            {
                Email = registerDTO.Email,
                UserName = registerDTO.Email,
                FullName = registerDTO.FullName,
                FCM = registerDTO.FCM,
                Zoon_Id = registerDTO.Zoon_Id,
                PhoneNumber = registerDTO.Phone
            };
            var result = await _userManager.CreateAsync(user, registerDTO.Password);
            if(result.Succeeded)
            {
                // Adding User To User Role
                await _userManager.AddToRoleAsync(user, Constants.UserRoleName);
                // Create JWT
                var tokenJson = _authenticationHandler.CreateToken(user, Constants.UserRoleName);

                registerState.RegisterSuccessfully = true;
                registerState.Token = tokenJson;
                registerState.User_Id = user.Id;
                return registerState;
            }
            registerState.ErrorMessages.AddRange(result.Errors.Select(error => error.Description).ToList());
            return registerState;
        }
    }
}
