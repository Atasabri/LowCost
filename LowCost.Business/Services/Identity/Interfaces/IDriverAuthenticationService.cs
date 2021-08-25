using LowCost.Infrastructure.DTOs.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Identity.Interfaces
{
    public interface IDriverAuthenticationService
    {
        /// <summary>
        /// Login To Driver System Using Email And Password Asynchronous
        /// </summary>
        /// <param name="loginDTO"></param>
        /// <returns></returns>
        Task<LoginState> LoginAsync(LoginDTO loginDTO);
    }
}
