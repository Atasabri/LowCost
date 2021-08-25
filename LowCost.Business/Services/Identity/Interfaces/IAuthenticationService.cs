using LowCost.Infrastructure.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Identity.Interfaces
{
    public interface IAuthenticationService
    {
        /// <summary>
        /// Login To User System Using Email And Password Asynchronous
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        Task<LoginState> LoginAsync(LoginDTO loginDTO);
        /// <summary>
        /// Login To User System Using External Login ID Asynchronous
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        Task<ExternalLoginState> ExternalLoginAsync(ExternalLoginDTO externalLoginDTO);
        /// <summary>
        /// Register To User System Using Asynchronous
        /// </summary>
        /// <param name="registerDTO"></param>
        /// <returns></returns>
        Task<RegisterState> RegisterAsync(RegisterDTO registerDTO);
    }
}
