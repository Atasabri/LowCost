using LowCost.Infrastructure.DTOs.User;
using LowCost.Infrastructure.DTOs.User.Driver;
using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.User.Interfaces
{
    public interface IDriverService
    {
        /// <summary>
        /// Edit Current Driver Profile Data Asynchronous
        /// </summary>
        /// <param name="editDriverProfileDTO"></param>
        /// <returns></returns>
        Task<ActionState> EditProfileAsync(EditDriverProfileDTO editDriverProfileDTO);
        /// <summary>
        /// Get Current Driver Profile Data Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<DriverProfileDTO> ProfileAsync();
        /// <summary>
        /// Change Driver Password Asynchronous
        /// </summary>
        /// <param name="changePasswordDTO"></param>
        /// <returns></returns>
        Task<ActionState> ChangePasswordAsync(ChangePasswordDTO changePasswordDTO);
    }
}
