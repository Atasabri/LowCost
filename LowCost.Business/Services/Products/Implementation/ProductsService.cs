using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Products.Interfaces;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DTOs.Products;
using LowCost.Infrastructure.Filtration;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Products.Implementation
{
    public class ProductsService : IProductsService
    {
        readonly int[] currentUserFavoritesProductsIds = new int[] { };
        readonly Action<IMappingOperationOptions<IEnumerable<Product>, IEnumerable<ListingProductDTO>>> opts = null;
        readonly Action<IMappingOperationOptions<Product, ProductDTO>> productDtoOpts = null;

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ProductsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;     
            // Change Current User Favorites Variable & Map Listing ProductDTO IsFav Property if User Logedin 
            if(_unitOfWork.CurrentUserRepository.CheckIfUserLogedin())
            {
                var user =  _unitOfWork.CurrentUserRepository.GetCurrentUser().Result;
                currentUserFavoritesProductsIds = _unitOfWork.FavoritesRepository
                    .GetElementsAsync(fav => fav.User_Id == user.Id).Result.Select(fav => fav.Product_Id).ToArray();
                // Get Current User Stock Id
                int? stock_Id = user.Zone_Id.HasValue ? _unitOfWork.ZonesRepository.FindByIdAsync(user.Zone_Id.Value).Result?.Stock_Id : null;
                // Product Listing After Mapping
                opts = opts => opts.AfterMap((src, dest) => {
                    foreach (var item in dest)
                    {
                        item.IsFav = currentUserFavoritesProductsIds.Contains(item.Id);
                        item.Quantity = stock_Id.HasValue ? item.StockProducts.FirstOrDefault(stockQuantity => stockQuantity.Stock_Id == stock_Id.Value)?.Quantity : null;
                    }
                });
                // Single Product After Mapping
                productDtoOpts = opts => opts.AfterMap((src, dest) =>
                {
                    dest.IsFav = currentUserFavoritesProductsIds.Contains(src.Id);
                    dest.Quantity = stock_Id.HasValue ? src.StockProducts.FirstOrDefault(stockQuantity => stockQuantity.Stock_Id == stock_Id.Value)?.Quantity : null;
                    dest.IsFollowing = _unitOfWork.ProductFollowingUsersRepository.FindElementAsync(follower => follower.Product_Id == src.Id) != null;
                });
            }
        }
        public async Task<ProductDTO> GetProductAsync(int id)
        {
            var product = await _unitOfWork.ProductsRepository
                   .FindElementAsync(product => product.Id == id,
                   string.Format("{0}.{1},{2},{3},{4}", nameof(Product.Prices),
                   nameof(Prices.Market), nameof(SubCategory),
                   nameof(Product.Brand), nameof(Product.StockProducts)));

            var productDTO = productDtoOpts == null ? _mapper.Map<Product, ProductDTO>(product) 
                                : _mapper.Map<Product, ProductDTO>(product, productDtoOpts);

            return productDTO;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsAsync(PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                   .GetElementsWithOrderAsync(product => true
                   , pagingParameters
                   , product => product.Id, OrderingType.Descending
                   , string.Format("{0}.{1},{2}", nameof(Product.Prices), nameof(Prices.Market), nameof(Product.StockProducts)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsHasDiscountAsync(PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                   .GetElementsAsync(product => product.Prices.Any(price => price.OldPrice.HasValue)
                   , pagingParameters
                   , string.Format("{0}.{1},{2}", nameof(Product.Prices), nameof(Prices.Market), nameof(Product.StockProducts)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsMostSellAsync(PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                   .GetElementsWithOrderAsync(product => product.OrderDetails.Count > 1
                   , pagingParameters
                   , product => product.OrderDetails.Count
                   , OrderingType.Descending,
                   string.Format("{0}.{1},{2},{3}", nameof(Product.Prices), nameof(Prices.Market), nameof(OrderDetails), nameof(Product.StockProducts)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsUsingCategoryIdAsync(int catId, PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                   .GetElementsAsync(product => product.SubCategory.Category_Id == catId
                   , pagingParameters
                   , string.Format("{0}.{1},{2},{3}", nameof(Product.Prices)
                   , nameof(Prices.Market)
                   , nameof(Product.SubCategory)
                   , nameof(Product.StockProducts)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }
        public async Task<PagedResult<ListingProductDTO>> GetProductsUsingSubCategoryIdAsync(int subCatId, PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                   .GetElementsAsync(product => product.SubCategory_Id == subCatId
                   , pagingParameters
                   , string.Format("{0}.{1},{2}", nameof(Product.Prices)
                   , nameof(Prices.Market), nameof(Product.StockProducts)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsUsingBrandIdAsync(int brandId, PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                    .GetElementsAsync(product => product.Brand_Id == brandId
                    , pagingParameters
                    , string.Format("{0}.{1},{2}", nameof(Product.Prices)
                    , nameof(Prices.Market), nameof(Product.StockProducts)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsRecommendedAsync(int productId, PagingParameters pagingParameters)
        {
            var product = await _unitOfWork.ProductsRepository.FindElementAsync(product => product.Id == productId,
                                nameof(Product.SubCategory));

            var products = await _unitOfWork.ProductsRepository.GetElementsAsync(prod =>
                                 prod.SubCategory.Category_Id == product.SubCategory.Category_Id
                                , pagingParameters
                                , string.Format("{0}.{1},{2},{3}", nameof(Product.Prices), nameof(Prices.Market)
                                , nameof(Product.SubCategory), nameof(Product.StockProducts)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsWithFiltrationAsync(ProductsFiltration productsFiltration)
        {
            var pagingParameters = new PagingParameters(productsFiltration.Index, productsFiltration.Size);


            var products = await _unitOfWork.ProductsRepository
                                .GetElementsWithOrderAsync(product =>
                                (productsFiltration.MainCategories.Length <= 0 || productsFiltration.MainCategories.Contains(product.SubCategory.Category.MainCategory_Id)) &&
                                (productsFiltration.Categories.Length <= 0 || productsFiltration.Categories.Contains(product.SubCategory.Category_Id)) &&
                                (productsFiltration.Brands.Length <= 0 || productsFiltration.Brands.Contains(product.Brand_Id)) &&
                                (product.Prices.Select(price => price.Market_Id).Any(x => productsFiltration.Markets.Length <= 0 || productsFiltration.Markets.Contains(x))) &&
                                product.Prices.Any(price => productsFiltration.LowPrice <= price.Price && price.Price <= productsFiltration.HighPrice)
                                , pagingParameters
                                , SortBy(productsFiltration.SortBy)
                                , productsFiltration.SortBy == OrderingBy.HighToLowPrice ? OrderingType.Descending : OrderingType.Ascending,
                                string.Format("{0}.{1},{2}.{3},{4}", nameof(Product.Prices)
                                , nameof(Prices.Market), nameof(Product.SubCategory),
                                nameof(Product.SubCategory.Category), nameof(Product.StockProducts)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }

        /// <summary>
        /// Filtration Sort By For Product Used in Lambda Expression
        /// </summary>
        /// <param name="orderingBy"></param>
        /// <returns></returns>
        private Expression<Func<Product, object>> SortBy(OrderingBy orderingBy)
        {
            if (orderingBy == OrderingBy.Name)
            {
                return product => product.Name;
            }
            else
            {
                return product => product.Prices.Min(price => price.Price);
            }
        }

        public async Task<PagedResult<ListingProductDTO>> GetProductsWithZeroCostAsync(PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository
                          .GetElementsWithOrderAsync(product => product.Prices.Min(price => price.Price) == 0
                          , pagingParameters
                          , product => product.Id
                          , OrderingType.Descending
                          , string.Format("{0}.{1},{2}", nameof(Product.Prices)
                          , nameof(Prices.Market), nameof(Product.StockProducts)));

            var productsDTOs = products.ToMappedPagedResult<Product, ListingProductDTO>(_mapper, opts);

            return productsDTOs;
        }
    }
}
