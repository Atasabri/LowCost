using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Sliders.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Sliders;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Manage_Files;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Sliders.Implementation.Dashboard
{
    public class DashboardSlidersService : IDashboardSlidersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardSlidersService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateSliderAsync(AddSliderViewModel addSliderViewModel)
        {
            var createState = new CreateState();
            var slider = _mapper.Map<AddSliderViewModel, Slider>(addSliderViewModel);

            await _unitOfWork.SlidersRepository.CreateAsync(slider);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                var imageData = new SavingFileData()
                {
                    File = addSliderViewModel.Photo,
                    fileName = slider.Id.ToString(),
                    folderName = "Sliders"
                };
                await _unitOfWork.FilesRepository.SaveFileAsync(imageData);
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Add Slider");
            return createState;
        }

        public async Task<ActionState> DeleteSliderAsync(int id)
        {
            var actionState = new ActionState();
            var slider = await _unitOfWork.SlidersRepository.FindByIdAsync(id);
            if (slider == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Slider !");
                return actionState;
            }
            _unitOfWork.SlidersRepository.Delete(slider);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                var imagedate = new FileBaseData()
                {
                    fileName = id.ToString(),
                    folderName = "Sliders"
                };
                await _unitOfWork.FilesRepository.DeleteFileAsync(imagedate);
            }
            actionState.ErrorMessages.Add("Can Not Delete Slider");
            return actionState;
        }

        public async Task<ActionState> EditSliderAsync(EditSliderViewModel editSliderViewModel)
        {
            var actionState = new ActionState();
            var slider = _mapper.Map<EditSliderViewModel, Slider>(editSliderViewModel);
            if (editSliderViewModel.Photo != null)
            {
                actionState.ExcuteSuccessfully = true;
                var imageData = new SavingFileData()
                {
                     File = editSliderViewModel.Photo,
                     fileName = slider.Id.ToString(),
                     folderName = "Sliders"
                };
                await _unitOfWork.FilesRepository.SaveFileAsync(imageData);
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Slider");
            return actionState;
        }

        public async Task<SliderViewModel> GetSliderDetailsAsync(int Id)
        {
            var slider = await _unitOfWork.SlidersRepository.FindByIdAsync(Id);

            var sliderViewModel = _mapper.Map<Slider, SliderViewModel>(slider);

            return sliderViewModel;
        }

        public async Task<PagedResult<SliderViewModel>> GetDashboardSlidersAsync(PagingParameters pagingParameters)
        {
            var sliders = await _unitOfWork.SlidersRepository.GetElementsWithOrderAsync(Slider => true,
                       pagingParameters, Slider => Slider.Id, OrderingType.Descending);

            var slidersViewModel = sliders.ToMappedPagedResult<Slider, SliderViewModel>(_mapper);

            return slidersViewModel;
        }
    }
}
