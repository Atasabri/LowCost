using LowCost.Business.Services.Verification.Interfaces;
using LowCost.Infrastructure.AppSettings;
using LowCost.Infrastructure.DTOs.Verification;
using LowCost.Infrastructure.Helpers;
using LowCost.Repo.UnitOfWork;
using LowCost.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using Nexmo.Api;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Verification.Implementation
{
    public class VerificationService : IVerificationService
    {
        private readonly UserManager<Domain.Models.User> _userManager;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        private readonly IUnitOfWork _unitOfWork;
        private readonly AppSettings _appSettings;

        public VerificationService(UserManager<Domain.Models.User> userManager,
            IOptions<AppSettings> appSettings,
            IStringLocalizer<SharedResource> stringLocalizer, IUnitOfWork unitOfWork)
        {
            this._userManager = userManager;
            this._stringLocalizer = stringLocalizer;
            this._unitOfWork = unitOfWork;
            this._appSettings = appSettings.Value;
        }

        public async Task<SendVerifyCodeResponse> SendVerifySMSAsync(SendVerifyCodeDTO sendVerifyCodeDTO)
        {
            var user = _userManager.Users.FirstOrDefault(user => user.PhoneNumber == sendVerifyCodeDTO.Phone);
            if(user != null)
            {
                // Create Random Code Contain 4 Numbers
                int smsCode = new Random().Next(1000, 9999);

                // Sending Request to SMSMisr
                int language = CultureInfo.CurrentCulture.Name == "ar" ? 2 : 1;
                string message = _stringLocalizer["Verification Code : {0}", smsCode.ToString()];
                HttpClient client = new HttpClient();
                Uri baseAddress = new Uri("https://smsmisr.com/");
                client.BaseAddress = baseAddress;
                var sendtime = DateTime.Now.ToString("yyyy-MM-dd-HH-mm");
                string query = "api/webapi/?" +
                $"username={_appSettings.Verification.ApiUserName}" +
                $"&password={_appSettings.Verification.ApiPassword}" +
                $"&language={language}" +
                $"&sender={_appSettings.Verification.SenderID}" +
                $"&mobile={sendVerifyCodeDTO.Phone}" +
                $"&message={message}" + "&DelayUntil=" + sendtime;
                HttpResponseMessage apiResponse = await client.PostAsync(query, null);

                string responseAsString = await apiResponse.Content.ReadAsStringAsync();
                var deserialized = JsonConvert.DeserializeObject<SendVerifyCodeResponse>(responseAsString);
                if (!string.IsNullOrEmpty(deserialized.SMSID))
                {
                    // Adding Code to DB to Check Later and Expire After 5 Min
                    var smsModel = new Domain.Models.SmsCode
                    {
                        Phone = sendVerifyCodeDTO.Phone,
                        SmsId = deserialized.SMSID,
                        Code = smsCode,
                        Expire = DateTimeProvider.GetEgyptDateTime().AddMinutes(5)
                    };
                    await _unitOfWork.SMSCodeRepository.CreateAsync(smsModel);
                    await _unitOfWork.SaveAsync();
                }
                else
                {
                    deserialized.Error = "Can Not Send Message";
                }
                return deserialized;
            }
            return new SendVerifyCodeResponse { Error = _stringLocalizer["No User With Phone '{0}'", sendVerifyCodeDTO.Phone] };
        }

        public async Task<CheckVerificationCodeResponse> CheckVerifyCodeAsync(CheckVerificationCodeDTO checkVerificationCode)
        {
            var response = new CheckVerificationCodeResponse();
            var user = _userManager.Users.FirstOrDefault(user => user.PhoneNumber == checkVerificationCode.Phone);
            if(user != null)
            {
                var sms = await _unitOfWork.SMSCodeRepository.
                    FindElementAsync(sms => sms.Code == checkVerificationCode.Code 
                    && sms.Phone == checkVerificationCode.Phone
                    && sms.SmsId == checkVerificationCode.SmsId
                    && DateTimeProvider.GetEgyptDateTime() < sms.Expire);

                if(sms != null)
                {
                    response.Status = true;
                    response.ResetPasswordToken = await _userManager.GeneratePasswordResetTokenAsync(user);
                    _unitOfWork.SMSCodeRepository.Delete(sms);
                    await _unitOfWork.SaveAsync();
                }
            }
            else
            {
                response.Error = _stringLocalizer["No User With Phone '{0}'", checkVerificationCode.Phone];
            }

            return response;
        }
    }
}
