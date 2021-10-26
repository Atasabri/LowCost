using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Offers.Interfaces;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DTOs.Offers;
using LowCost.Infrastructure.DTOs.Products;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Offers.Implementation
{
    public class OffersService : IOffersService
    {
        int[] currentUserFavoritesProductsIds = new int[] { };
        Action<IMappingOperationOptions<IEnumerable<Product>, IEnumerable<ListingProductDTO>>> opts = null;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly UserManager<Domain.Models.User> _userManager;

        public OffersService(IUnitOfWork unitOfWork, IMapper mapper, UserManager<Domain.Models.User> userManager)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
            this._userManager = userManager;
            // Change Current User Favorites Variable & Map Listing ProductDTO IsFav Property if User Logedin 
            if (_unitOfWork.CurrentUserRepository.CheckIfUserLogedin())
            {
                var userId = _unitOfWork.CurrentUserRepository.GetCurrentUserId().Result;
                currentUserFavoritesProductsIds = _unitOfWork.FavoritesRepository
                    .GetElementsAsync(fav => fav.User_Id == userId).Result.Select(fav => fav.Product_Id).ToArray();

                opts = opts => opts.AfterMap((src, dest) => {
                    foreach (var item in dest)
                    {
                        item.IsFav = currentUserFavoritesProductsIds.Contains(item.Id);
                    }
                });
            }
        }
        public async Task<OfferDTO> GetLowCostOfferAsync()
        {
            // Get Low Cost Offer
            var lowCostOffer = await _unitOfWork.OffersRepository.FindByIdAsync(Constants.LowCostOfferId);

            var lowCostOfferDTO = _mapper.Map<Offer, OfferDTO>(lowCostOffer);

            return lowCostOfferDTO;
        }

        public async Task<PagedResult<ListingProductDTO>> GetOfferProductsAsync(int offerId, PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository.GetElementsWithOrderAsync(product => product.Offer_Id == offerId
                                 , pagingParameters
                                 , product => product.Id, OrderingType.Descending
                                 , string.Format("{0}.{1}", nameof(Product.Prices), nameof(Prices.Market)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);
            return productsDTOs;
        }

        public async Task<PagedResult<OfferDTO>> GetOffersAsync(PagingParameters pagingparameters)
        {

            // Change Last Access Of Current User
            var user = await _unitOfWork.CurrentUserRepository.GetCurrentUser();
            if(user != null)
            {
                user.LastAccessOffers = DateTimeProvider.GetEgyptDateTime();
                await _userManager.UpdateAsync(user);
            }

            // Getting All Offers With Desc Order Except Low Cost Offer
            var offers = await _unitOfWork.OffersRepository.GetElementsWithOrderAsync(offer => offer.Id != Constants.LowCostOfferId
                              , pagingparameters
                              , offer => offer.Id , OrderingType.Descending);

            var offersDTOs = offers.ToMappedPagedResult<Offer, OfferDTO>(_mapper);
            return offersDTOs;
        }

        public async Task<int> GetOffersCountCurrentUserNotAccessAsync()
        {
            var user = await _unitOfWork.CurrentUserRepository.GetCurrentUser();
            if(user != null)
            {
                var offersCount = await _unitOfWork.OffersRepository.GetCountAsync(offer => offer.IsNew && offer.UpdatedDate > user.LastAccessOffers);

                return offersCount;
            }
            return 0;
        }
    }
}
