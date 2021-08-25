using LowCost.Infrastructure.DTOs.Verification;
using Nexmo.Api;
using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Verification.Interfaces
{
    public interface IVerificationService
    {
        /// <summary>
        /// Send Verification Code To Phone
        /// </summary>
        /// <param name="sendVerifyCodeDTO"></param>
        /// <returns></returns>
        Task<SendVerifyCodeResponse> SendVerifySMSAsync(SendVerifyCodeDTO sendVerifyCodeDTO);
        /// <summary>
        /// Check Verification Code And Return Reset Password Token
        /// </summary>
        /// <param name="checkVerificationCode"></param>
        /// <returns></returns>
        Task<CheckVerificationCodeResponse> CheckVerifyCodeAsync(CheckVerificationCodeDTO checkVerificationCode);

    }
}
