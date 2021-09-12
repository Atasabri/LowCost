using LowCost.Infrastructure.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.ProductFollowingUsersService.Interfaces
{
    public interface IProductFollowingUsersService
    {
        /// <summary>
        /// Adding Current User To Product Following Asynchronous
        /// </summary>
        /// <param name="product_Id"></param>
        /// <returns></returns>
        Task<ActionState> FollowProductAsync(int product_Id);
        /// <summary>
        /// Removing Current User From Product Following Asynchronous
        /// </summary>
        /// <param name="product_Id"></param>
        /// <returns></returns>
        Task<ActionState> UnFollowProductAsync(int product_Id);
    }
}
