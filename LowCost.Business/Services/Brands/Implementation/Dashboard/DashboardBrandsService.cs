using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Brands.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Brand;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Manage_Files;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Brands.Implementation.Dashboard
{
    public class DashboardBrandsService : IDashboardBrandsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardBrandsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }

        public async Task<ActionState> ChangeViewInAppAsync(int Id, bool viewInApp)
        {
            var actionState = new ActionState();
            // Get Brand And Change It's ViewinApp prop
            var brand = await _unitOfWork.BrandsRepository.FindByIdAsync(Id);
            if(brand != null)
            {
                brand.ViewInApp = viewInApp;
                _unitOfWork.BrandsRepository.Update(brand);
                var result = await _unitOfWork.SaveAsync() > 0;
                if(result)
                {
                    actionState.ExcuteSuccessfully = true;
                    return actionState;
                }
            }
            actionState.ErrorMessages.Add("Can Not Edit This Brand !!");
            return actionState;
        }

        public async Task<CreateState> CreateBrandAsync(AddBrandViewModel addBrandViewModel)
        {
            var createState = new CreateState();
            var brand = _mapper.Map<AddBrandViewModel, Brand>(addBrandViewModel);

            await _unitOfWork.BrandsRepository.CreateAsync(brand);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                // Adding Brand Photo
                var imageData = new SavingFileData()
                {
                    File = addBrandViewModel.Photo,
                    fileName = brand.Id.ToString(),
                    folderName = "Brands"
                };
                await _unitOfWork.FilesRepository.SaveFileAsync(imageData);
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create Brand");
            return createState;
        }

        public async Task<ActionState> DeleteBrandAsync(int id)
        {
            var actionState = new ActionState();
            var brand = await _unitOfWork.BrandsRepository.FindByIdAsync(id);
            if (brand == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Brand !");
                return actionState;
            }
            _unitOfWork.BrandsRepository.Delete(brand);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                // Delete Brand Photo
                var imagedate = new FileBaseData()
                {
                    fileName = id.ToString(),
                    folderName = "Brands"
                };
                await _unitOfWork.FilesRepository.DeleteFileAsync(imagedate);
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Brand");
            return actionState;
        }

        public async Task<ActionState> EditBrandAsync(EditBrandViewModel editBrandViewModel)
        {
            var actionState = new ActionState();
            var brand = _mapper.Map<EditBrandViewModel, Brand>(editBrandViewModel);
            _unitOfWork.BrandsRepository.Update(brand);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                // Replace Brand Photo If Photo Edited
                if (editBrandViewModel.Photo != null)
                {
                    var imageData = new SavingFileData()
                    {
                        File = editBrandViewModel.Photo,
                        fileName = brand.Id.ToString(),
                        folderName = "Brands"
                    };
                    await _unitOfWork.FilesRepository.SaveFileAsync(imageData);
                }
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Brand");
            return actionState;
        }

        public async Task<IEnumerable<BrandViewModel>> GetAllBrandsAsync()
        {
            var brands = await _unitOfWork.BrandsRepository.GetElementsAsync(brand => true);

            var brandsViewModel = _mapper.Map<IEnumerable<Brand>, IEnumerable<BrandViewModel>>(brands);

            return brandsViewModel;
        }

        public async Task<BrandViewModel> GetBrandDetailsAsync(int Id)
        {
            var brand = await _unitOfWork.BrandsRepository.FindByIdAsync(Id);

            var brandViewModel = _mapper.Map<Brand, BrandViewModel>(brand);

            return brandViewModel;
        }

        public async Task<PagedResult<BrandViewModel>> GetDashboardBrandsAsync(PagingParameters pagingParameters)
        {
            var brands = await _unitOfWork.BrandsRepository.GetElementsWithOrderAsync(brand => true,
                       pagingParameters, brand => brand.OrderKey, OrderingType.Ascending);

            var brandsViewModel = brands.ToMappedPagedResult<Brand, BrandViewModel>(_mapper);

            return brandsViewModel;
        }

        public async Task<ActionState> OrderBrandsListAsync(int[] orderListItems)
        {
            var actionState = new ActionState();
            for (int i = 0; i < orderListItems.Length; i++)
            {
                var brand = await _unitOfWork.BrandsRepository.FindByIdAsync(orderListItems[i]);
                if (brand != null && brand.OrderKey != i)
                {
                    brand.OrderKey = i;
                    _unitOfWork.BrandsRepository.Update(brand);
                }
            }
            var result = await _unitOfWork.SaveAsync() > 0;
            actionState.ExcuteSuccessfully = result;
            return actionState;
        }
    }
}
