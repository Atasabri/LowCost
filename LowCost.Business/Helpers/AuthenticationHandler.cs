using LowCost.Domain.Models;
using LowCost.Infrastructure.Helpers;
using LowCost.Resources;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Helpers
{
    public class AuthenticationHandler
    {
        private readonly UserManager<User> _userManager;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public AuthenticationHandler(UserManager<Domain.Models.User> userManager, IStringLocalizer<SharedResource> stringLocalizer)
        {
            this._userManager = userManager;
            this._stringLocalizer = stringLocalizer;
        }
        public string CreateToken(Domain.Models.User user, string roleName)
        {
            // Create Claims For User
            var authClaims = new List<Claim>
                    {
                          new Claim(ClaimTypes.Name, user.UserName),
                          new Claim(ClaimTypes.NameIdentifier, user.Id),
                          new Claim(JwtRegisteredClaimNames.Jti, user.Id),
                          new Claim(ClaimTypes.Role, roleName)
                    };

            var secretBytes = Encoding.UTF8.GetBytes(Constants.Secret);
            var key = new SymmetricSecurityKey(secretBytes);
            var algorithm = SecurityAlgorithms.HmacSha256;

            var signingCredentials = new SigningCredentials(key, algorithm);

            var token = new JwtSecurityToken(
                Constants.Issuer,
                Constants.Audiance,
                authClaims,
                notBefore: DateTime.UtcNow,
                expires: DateTime.UtcNow.AddDays(15),
                signingCredentials);


            var tokenJson = new JwtSecurityTokenHandler().WriteToken(token);

            return tokenJson;
        }


        public async Task ChangeUserFCMAsync(Domain.Models.User user, string FCM)
        {
            user.FCM = FCM;
            await _userManager.UpdateAsync(user);
        }

        public async Task<ActionState> CheckPhoneNumberAvailableAsync(string phoneNumber, string userId = null)
        {
            var actionState = new ActionState();
            if (string.IsNullOrEmpty(phoneNumber))
            {
                actionState.ErrorMessages.Add(_stringLocalizer["Phone Number Is Unique."]);
                return actionState;
            }
            if (!int.TryParse(phoneNumber, out _))
            {
                actionState.ErrorMessages.Add(_stringLocalizer["Phone Number '{0}' is invalid.", phoneNumber]);
                return actionState;
            }
            var phoneUsed = await _userManager.Users.AnyAsync(user => user.Id != userId && user.PhoneNumber == phoneNumber);
            if (phoneUsed)
            {
                actionState.ErrorMessages.Add(_stringLocalizer["Phone Number '{0}' already taken.", phoneNumber]);
                return actionState;
            }
            actionState.ExcuteSuccessfully = true;
            return actionState;
        }
    }
}
