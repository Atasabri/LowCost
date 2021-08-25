using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Categories.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Categories;
using LowCost.Infrastructure.DashboardViewModels.Categories.SubCategories;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Manage_Files;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Categories.Implementation.Dashboard
{
    public class DashboardSubCategoriesService : IDashboardSubCategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardSubCategoriesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateSubCategoryAsync(AddSubCategoryViewModel addSubCategoryViewModel)
        {
            var createState = new CreateState();
            var subCategory = _mapper.Map<AddSubCategoryViewModel, SubCategory>(addSubCategoryViewModel);

            await _unitOfWork.SubCategoriesRepository.CreateAsync(subCategory);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                // Adding Sub Category Photo
                var imageData = new SavingFileData()
                {
                    File = addSubCategoryViewModel.Photo,
                    fileName = subCategory.Id.ToString(),
                    folderName = "SubCategories"
                };
                await _unitOfWork.FilesRepository.SaveFileAsync(imageData);
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create Sub Category");
            return createState;
        }

        public async Task<ActionState> DeleteSubCategoryAsync(int id)
        {
            var actionState = new ActionState();
            var subCategory = await _unitOfWork.SubCategoriesRepository.FindByIdAsync(id);
            if (await GetSubCategoryDetailsAsync(subCategory.Id) == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Sub Category !");
                return actionState;
            }
            _unitOfWork.SubCategoriesRepository.Delete(subCategory);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                // Delete Sub Category Photo
                var imagedate = new FileBaseData()
                {
                    fileName = id.ToString(),
                    folderName = "SubCategories"
                };
                await _unitOfWork.FilesRepository.DeleteFileAsync(imagedate);
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Sub Category");
            return actionState;
        }

        public async Task<ActionState> EditSubCategoryAsync(EditSubCategoryViewModel editSubCategoryViewModel)
        {
            var actionState = new ActionState();
            var subCategory = _mapper.Map<EditSubCategoryViewModel, SubCategory>(editSubCategoryViewModel);
            _unitOfWork.SubCategoriesRepository.Update(subCategory);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                // Replace Sub Category Photo If Photo Edited
                if (editSubCategoryViewModel.Photo != null)
                {
                    var imageData = new SavingFileData()
                    {
                        File = editSubCategoryViewModel.Photo,
                        fileName = subCategory.Id.ToString(),
                        folderName = "SubCategories"
                    };
                    await _unitOfWork.FilesRepository.SaveFileAsync(imageData);
                }
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Sub Category");
            return actionState;
        }

        public async Task<SubCategoryViewModel> GetSubCategoryDetailsAsync(int Id)
        {
            var subCategory = await _unitOfWork.SubCategoriesRepository.FindElementAsync(subCat => subCat.Id == Id,
                 nameof(SubCategory.Category));

            var subCategoryViewModel = _mapper.Map<SubCategory, SubCategoryViewModel>(subCategory);

            return subCategoryViewModel;
        }

        public async Task<PagedResult<SubCategoryViewModel>> GetDashboardSubCategoriesAsync(PagingParameters pagingParameters)
        {
            var subCategories = await _unitOfWork.SubCategoriesRepository.GetElementsWithOrderAsync(cat => true,
                       pagingParameters, cat => cat.Id, OrderingType.Descending,
                       nameof(SubCategory.Category));

            var pagedSubCategoriesViewModel = subCategories.ToMappedPagedResult<SubCategory, SubCategoryViewModel>(_mapper);

            return pagedSubCategoriesViewModel;
        }

        public async Task<IEnumerable<SubCategoryViewModel>> GetAllSubCategoriesUsingCategoryIdAsync(int catId)
        {
            var subCategories = await _unitOfWork.SubCategoriesRepository.GetElementsAsync(cat => cat.Category_Id == catId);

            var subCategoriesViewModel = _mapper.Map<IEnumerable<SubCategory>, IEnumerable<SubCategoryViewModel>>(subCategories);

            return subCategoriesViewModel;
        }
    }
}
