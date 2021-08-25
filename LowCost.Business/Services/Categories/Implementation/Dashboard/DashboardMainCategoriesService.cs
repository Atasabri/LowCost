using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Categories.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Categories;
using LowCost.Infrastructure.DashboardViewModels.Categories.MainCategories;
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
    public class DashboardMainCategoriesService : IDashboardMainCategoriesService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardMainCategoriesService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateMainCategoryAsync(AddMainCategoryViewModel addMainCategoryViewModel)
        {
            var createState = new CreateState();
            var mainCategory = _mapper.Map<AddMainCategoryViewModel, MainCategory>(addMainCategoryViewModel);

            await _unitOfWork.MainCategoriesRepository.CreateAsync(mainCategory);
            var result = await _unitOfWork.SaveAsync() > 0;
            if(result)
            {
                createState.CreatedSuccessfully = true;
                // Adding Main Category Photo
                var imageData = new SavingFileData()
                {
                    File = addMainCategoryViewModel.Photo,
                    fileName = mainCategory.Id.ToString(),
                    folderName = "MainCategories"
                };
                await _unitOfWork.FilesRepository.SaveFileAsync(imageData);
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Add Main Category");
            return createState;
        }

        public async Task<ActionState> DeleteMainCategoryAsync(int id)
        {
            var actionState = new ActionState();
            var mainCategory = await _unitOfWork.MainCategoriesRepository.FindByIdAsync(id);
            if (mainCategory == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Main Category !");
                return actionState;
            }
            _unitOfWork.MainCategoriesRepository.Delete(mainCategory);
            var result = await _unitOfWork.SaveAsync() > 0;
            if(result)
            {
                actionState.ExcuteSuccessfully = true;
                // Delete Main Category Photo
                var imagedate = new FileBaseData()
                {
                    fileName = id.ToString(),
                    folderName = "MainCategories"
                };
                await _unitOfWork.FilesRepository.DeleteFileAsync(imagedate);
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Main Category");
            return actionState;
        }

        public async Task<ActionState> EditMainCategoryAsync(EditMainCategoryViewModel editMainCategoryViewModel)
        {
            var actionState = new ActionState();
            var mainCategory = _mapper.Map<EditMainCategoryViewModel, MainCategory>(editMainCategoryViewModel);
            _unitOfWork.MainCategoriesRepository.Update(mainCategory);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                // Replace Main Category Photo If Photo Edited
                if (editMainCategoryViewModel.Photo != null)
                {
                    var imageData = new SavingFileData()
                    {
                        File = editMainCategoryViewModel.Photo,
                        fileName = mainCategory.Id.ToString(),
                        folderName = "MainCategories"
                    };
                    await _unitOfWork.FilesRepository.SaveFileAsync(imageData);
                }               
            }
            actionState.ErrorMessages.Add("Can Not Edit Main Category");
            return actionState;
        }

        public async Task<IEnumerable<MainCategoryViewModel>> GetAllMainCategoriesAsync()
        {
            var mainCategories = await _unitOfWork.MainCategoriesRepository.GetElementsAsync(mainCat => true);

            var mainCategoriesViewModel = _mapper.Map<IEnumerable<MainCategory>, IEnumerable<MainCategoryViewModel>>(mainCategories);

            return mainCategoriesViewModel;
        }

        public async Task<PagedResult<MainCategoryViewModel>> GetDashboardMainCategoriesAsync(PagingParameters pagingParameters)
        {
            var mainCategories = await _unitOfWork.MainCategoriesRepository.GetElementsWithOrderAsync(mainCat => true,
                                   pagingParameters, mainCat => mainCat.Id, OrderingType.Descending);

            var pagedMainCategoriesViewModel = mainCategories.ToMappedPagedResult<MainCategory, MainCategoryViewModel>(_mapper);

            return pagedMainCategoriesViewModel;
        }

        public async Task<MainCategoryViewModel> GetMainCategoryDetailsAsync(int Id)
        {
            var mainCategory = await _unitOfWork.MainCategoriesRepository.FindByIdAsync(Id);

            var mainCategoryViewModel = _mapper.Map<MainCategory, MainCategoryViewModel>(mainCategory);

            return mainCategoryViewModel;
        }
    }
}
