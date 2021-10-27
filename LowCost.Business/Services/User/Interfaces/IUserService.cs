using LowCost.Infrastructure.DTOs.User;
using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.User.Interfaces
{
    public interface IUserService
    {
        /// <summary>
        /// Reset User Password of Current User Asynchronous
        /// </summary>
        /// <param name="resetPasswordDTO"></param>
        /// <returns></returns>
        Task<ActionState> ResetPasswordAsync(ResetPasswordDTO resetPasswordDTO);
        /// <summary>
        /// Edit Current User Profile Data Asynchronous
        /// </summary>
        /// <param name="editProfileDTO"></param>
        /// <returns></returns>
        Task<ActionState> EditProfileAsync(EditProfileDTO editProfileDTO);
        /// <summary>
        /// Edit Current User Password Asynchronous
        /// </summary>
        /// <param name="changePasswordDTO"></param>
        /// <returns></returns>
        Task<ActionState> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO);
        /// <summary>
        /// Get Current User Profile Data Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<ProfileDTO> ProfileAsync();
        /// <summary>
        /// Change The Current User His Current Language Flag in Database Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<ActionState> ChangeLoginedUserCurrentLanguageAsync(Languages language);
        /// <summary>
        /// Change Current User Zone Asynchronous
        /// </summary>
        /// <param name="zoneId"></param>
        /// <returns></returns>
        Task<ActionState> ChangeCurrentUserZoneAsync(int zoneId);
        /// <summary>
        /// Change Current User Last Access Low Cost Offer to Current Date Time Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<ActionState> ChangeCurrentUseLasrAccessLowCostOfferAsync();
    }
}
