using LowCost.Infrastructure.DTOs.User.PaymentMethods;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.User.Interfaces
{
    public interface IPaymentMethodsService
    {
        /// <summary>
        /// Adding New Payment Method to Current Logined User Asynchronous
        /// </summary>
        /// <param name="addPaymentMethodDTO"></param>
        /// <returns></returns>
        Task<CreateState> AddPaymentMethodAsync(AddPaymentMethodDTO addPaymentMethodDTO);
        /// <summary>
        /// Delete Payment Method Using Payment Method Id Asynchronous
        /// </summary>
        /// <param name="deletePaymentMethodDTO"></param>
        /// <returns></returns>
        Task<ActionState> RemovePaymentMethodAsync(DeletePaymentMethodDTO deletePaymentMethodDTO);
        /// <summary>
        /// Get Current Logined User Payment Methods (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<PaymentMethodDTO>> GetUserPaymentMethodsAsync(PagingParameters pagingParameters);
    }
}
