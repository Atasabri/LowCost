using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.PromoCodes.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.PromoCodes;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Manage_Files;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.PromoCodes.Implementation.Dashboard
{
    public class DashboardPromoCodeService : IDashboardPromoCodeService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardPromoCodeService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreatePromoCodeAsync(AddPromoCodeViewModel addPromoCodeViewModel)
        {
            var createState = new CreateState();
            var promoCode = _mapper.Map<AddPromoCodeViewModel, PromoCode>(addPromoCodeViewModel);

            await _unitOfWork.PromoCodesRepository.CreateAsync(promoCode);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create PromoCode");
            return createState;
        }

        public async Task<ActionState> DeletePromoCodeAsync(int id)
        {
            var actionState = new ActionState();
            var promoCode = await _unitOfWork.PromoCodesRepository.FindByIdAsync(id);
            if (promoCode == null)
            {
                actionState.ErrorMessages.Add("Can Not Find PromoCode !");
                return actionState;
            }
            _unitOfWork.PromoCodesRepository.Delete(promoCode);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete PromoCode");
            return actionState;
        }

        public async Task<ActionState> EditPromoCodeAsync(EditPromoCodeViewModel editPromoCodeViewModel)
        {
            var actionState = new ActionState();
            var promoCode = _mapper.Map<EditPromoCodeViewModel, PromoCode>(editPromoCodeViewModel);
            _unitOfWork.PromoCodesRepository.Update(promoCode);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit PromoCode");
            return actionState;
        }

        public async Task<PromoCodeViewModel> GetPromoCodeDetailsAsync(int Id)
        {
            var promoCode = await _unitOfWork.PromoCodesRepository.FindElementAsync(code => code.Id == Id, 
                          string.Format("{0},{1},{2}"
                          , nameof(PromoCode.Category)
                          , nameof(PromoCode.SubCategory)
                          ,nameof(PromoCode.Zone)));

            var promoCodeViewModel = _mapper.Map<PromoCode, PromoCodeViewModel>(promoCode);

            return promoCodeViewModel;
        }

        public async Task<PagedResult<PromoCodeViewModel>> GetDashboardPromoCodesAsync(PagingParameters pagingParameters)
        {
            var promoCodes = await _unitOfWork.PromoCodesRepository.GetElementsWithOrderAsync(PromoCode => true,
                       pagingParameters, PromoCode => PromoCode.Id, OrderingType.Descending);

            var promoCodesViewModel = promoCodes.ToMappedPagedResult<PromoCode, PromoCodeViewModel>(_mapper);

            return promoCodesViewModel;
        }
    }
}
