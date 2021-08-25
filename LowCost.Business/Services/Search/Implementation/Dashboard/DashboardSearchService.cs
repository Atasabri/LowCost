using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Search.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Orders;
using LowCost.Infrastructure.DashboardViewModels.Products;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Search.Implementation.Dashboard
{
    public class DashboardSearchService : IDashboardSearchService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardSearchService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<PagedResult<ListingOrderViewModel>> SearchOrdersAsync(int id, PagingParameters pagingParameters)
        {
            var orders = await _unitOfWork.OrdersRepository.GetElementsWithOrderAsync(order => order.Id == id, pagingParameters,
                               order => order.DateTime, OrderingType.Descending);

            var ordersViewModel = orders.ToMappedPagedResult<Order, ListingOrderViewModel>(_mapper);
            return ordersViewModel;
        }

        public async Task<PagedResult<ListingProductViewModel>> SearchProductsAsync(string searchTerms, PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository.GetElementsWithOrderAsync(product => product.Name.Contains(searchTerms) || product.Name_AR.Contains(searchTerms) || product.Serial_Number == searchTerms,
                              pagingParameters, Product => Product.Id, OrderingType.Descending,
                              nameof(Product.SubCategory));

            var productsViewModel = products.ToMappedPagedResult<Product, ListingProductViewModel>(_mapper);

            return productsViewModel;
        }
    }
}
