﻿using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Products.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Products;
using LowCost.Infrastructure.DashboardViewModels.Products.Prices;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Manage_Files;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Products.Implementation.Dashboard
{
    public class DashboardProductsService : IDashboardProductsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardProductsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateProductAsync(AddProductViewModel addProductViewModel)
        {
            var createState = new CreateState();
            if(addProductViewModel.Prices?.Count == 0)
            {
                createState.ErrorMessages.Add("You Must Add Price");
                return createState;
            }
            var product = _mapper.Map<AddProductViewModel, Product>(addProductViewModel);
            await _unitOfWork.ProductsRepository.CreateAsync(product);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                var imageData = new SavingFileData()
                {
                    File = addProductViewModel.Photo,
                    fileName = product.Id.ToString(),
                    folderName = "Products"
                };
                await _unitOfWork.FilesRepository.SaveFileAsync(imageData);
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create Product");
            return createState;
        }

        public async Task<ActionState> DeleteProductAsync(int id)
        {
            var actionState = new ActionState();
            var product = await _unitOfWork.ProductsRepository.FindByIdAsync(id);
            if (product == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Product !");
                return actionState;
            }
            _unitOfWork.ProductsRepository.Delete(product);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                var imagedate = new FileBaseData()
                {
                    fileName = id.ToString(),
                    folderName = "Products"
                };
                await _unitOfWork.FilesRepository.DeleteFileAsync(imagedate);
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Product");
            return actionState;
        }

        public async Task<ActionState> EditProductAsync(EditProductViewModel editProductViewModel)
        {
            var actionState = new ActionState();
            var productPrices = await _unitOfWork.PricesRepository.GetElementsAsync(price => price.Product_Id == editProductViewModel.Id);
            if(productPrices.Count() == editProductViewModel.DeletingPrices.Length && editProductViewModel.AddingPrices.Count == 0)
            {
                actionState.ErrorMessages.Add("You Must Add Price");
                return actionState;
            }
            var product = _mapper.Map<EditProductViewModel, Product>(editProductViewModel);
            _unitOfWork.ProductsRepository.Update(product);
            foreach (int priceId in editProductViewModel.DeletingPrices)
            {
               var deletePrice = await _unitOfWork.PricesRepository.FindByIdAsync(priceId);
                _unitOfWork.PricesRepository.Delete(deletePrice);
            }
            var addingPrices = _mapper.Map<List<AddPriceViewModel>, List<Prices>>(editProductViewModel.AddingPrices);
            foreach (var addPrice in addingPrices)
            {
                addPrice.Product_Id = editProductViewModel.Id;
                await _unitOfWork.PricesRepository.CreateAsync(addPrice);
            }
            
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                if (editProductViewModel.Photo != null)
                {
                    var imageData = new SavingFileData()
                    {
                        File = editProductViewModel.Photo,
                        fileName = product.Id.ToString(),
                        folderName = "Products"
                    };
                    await _unitOfWork.FilesRepository.SaveFileAsync(imageData);
                }
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Product");
            return actionState;
        }

        public async Task<ProductViewModel> GetProductDetailsAsync(int Id)
        {
            var product = await _unitOfWork.ProductsRepository.FindElementAsync(product => product.Id == Id,
                string.Format("{0},{1},{2}.{3},{4}", nameof(Product.SubCategory)
                , nameof(Product.Offer),
                nameof(Product.Prices), nameof(Prices.Market), nameof(Product.Brand)));

            var productViewModel = _mapper.Map<Product, ProductViewModel>(product);

            return productViewModel;
        }

        public async Task<PagedResult<ListingProductViewModel>> GetDashboardProductsAsync(PagingParameters pagingParameters)
        {
            var products = await _unitOfWork.ProductsRepository.GetElementsWithOrderAsync(Product => true,
                       pagingParameters, Product => Product.Id, OrderingType.Descending,
                        string.Format("{0},{1}", nameof(Product.SubCategory), nameof(Product.Brand)));

            var productsViewModel = products.ToMappedPagedResult<Product, ListingProductViewModel>(_mapper);

            return productsViewModel;
        }

        public async Task<PriceViewModel> GetPriceDetailsAsync(int Id)
        {
            var price = await _unitOfWork.PricesRepository.FindElementAsync(price => price.Id == Id, nameof(Prices.Market));

            var priceViewModel = _mapper.Map<Prices, PriceViewModel>(price);
            return priceViewModel;
        }

        public async Task<ActionState> EditPriceAsync(EditPriceViewModel editPriceViewModel)
        {
            var actionState = new ActionState();
            var price = _mapper.Map<EditPriceViewModel, Prices>(editPriceViewModel);
            _unitOfWork.PricesRepository.Update(price);
            var result = await _unitOfWork.SaveAsync() > 0;
            if(result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Error In Edit Price");
            return actionState;
        }
    }
}
