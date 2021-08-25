using LowCost.Infrastructure.DashboardViewModels.PromoCodes;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.PromoCodes.Interfaces.Dashboard
{
    public interface IDashboardPromoCodeService
    {
        /// <summary>
        /// Adding New PromoCode Asynchronous
        /// </summary>
        /// <param name="addPromoCodeViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreatePromoCodeAsync(AddPromoCodeViewModel addPromoCodeViewModel);
        /// <summary>
        /// Edit PromoCode Asynchronous
        /// </summary>
        /// <param name="editPromoCodeViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditPromoCodeAsync(EditPromoCodeViewModel editPromoCodeViewModel);
        /// <summary>
        /// Delete PromoCode Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeletePromoCodeAsync(int id);
        /// <summary>
        /// Get PromoCodes (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<PromoCodeViewModel>> GetDashboardPromoCodesAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get PromoCode Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<PromoCodeViewModel> GetPromoCodeDetailsAsync(int Id);
    }
}
