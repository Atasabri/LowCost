using LowCost.Infrastructure.DashboardViewModels.Offers;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Offers.Interfaces.Dashboard
{
    public interface IDashboardOffersService
    {
        /// <summary>
        /// Adding New Offer Asynchronous
        /// </summary>
        /// <param name="addOfferViewModel"></param>
        /// <returns></returns>
        Task<CreateState> CreateOfferAsync(AddOfferViewModel addOfferViewModel);
        /// <summary>
        /// Edit Offer Asynchronous
        /// </summary>
        /// <param name="editOfferViewModel"></param>
        /// <returns></returns>
        Task<ActionState> EditOfferAsync(EditOfferViewModel editOfferViewModel);
        /// <summary>
        /// Delete Offer Using Id Asynchronous
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<ActionState> DeleteOfferAsync(int id);
        /// <summary>
        /// Get Offers (Asynchronous & Paging)
        /// </summary>
        /// <param name="pagingParameters"></param>
        /// <returns></returns>
        Task<PagedResult<OfferViewModel>> GetDashboardOffersAsync(PagingParameters pagingParameters);
        /// <summary>
        /// Get Offer Details Asynchronous
        /// </summary>
        /// <param name="Id"></param>
        /// <returns></returns>
        Task<OfferViewModel> GetOfferDetailsAsync(int Id);
        /// <summary>
        /// Get All Offers Asynchronous
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<OfferViewModel>> GetAllOffersAsync();
    }
}
