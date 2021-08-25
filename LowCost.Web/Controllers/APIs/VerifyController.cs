using LowCost.Business.Services.Verification.Interfaces;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.DTOs.Verification;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LowCost.Web.Controllers.APIs
{
    public class VerifyController : APIController
    {
        private readonly IVerificationService _verificationService;

        public VerifyController(IVerificationService verificationService)
        {
            this._verificationService = verificationService;
        }
        [HttpPost("SendVerifySMS")]
        public async Task<IActionResult> SendVerifySMS([FromBody] SendVerifyCodeDTO sendVerifyCodeDTO)
        {
            var result = await _verificationService.SendVerifySMSAsync(sendVerifyCodeDTO);
            return Ok(result);
        }

        [HttpPost("CheckVerifyCode")]
        public async Task<IActionResult> CheckVerifyCode([FromBody] CheckVerificationCodeDTO checkVerificationCode)
        {
            var result = await _verificationService.CheckVerifyCodeAsync(checkVerificationCode);
            if (result.Status)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
    }
}
