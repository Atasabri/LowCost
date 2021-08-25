using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Markets.Interfaces.Dashboard;
using LowCost.Domain.Models;
using LowCost.Infrastructure.DashboardViewModels.Markets;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Manage_Files;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Markets.Implementation.Dashboard
{
    public class DashboardMarketsService : IDashboardMarketsService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardMarketsService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateMarketAsync(AddMarketViewModel addMarketViewModel)
        {
            var createState = new CreateState();
            var market = _mapper.Map<AddMarketViewModel, Market>(addMarketViewModel);

            await _unitOfWork.MarketsRepository.CreateAsync(market);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                var imageData = new SavingFileData()
                {
                    File = addMarketViewModel.Photo,
                    fileName = market.Id.ToString(),
                    folderName = "Markets"
                };
                await _unitOfWork.FilesRepository.SaveFileAsync(imageData);
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create Market");
            return createState;
        }

        public async Task<ActionState> DeleteMarketAsync(int id)
        {
            var actionState = new ActionState();
            var market = await _unitOfWork.MarketsRepository.FindByIdAsync(id);
            if (market == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Market !");
                return actionState;
            }
            _unitOfWork.MarketsRepository.Delete(market);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                var imagedate = new FileBaseData()
                {
                    fileName = id.ToString(),
                    folderName = "Markets"
                };
                await _unitOfWork.FilesRepository.DeleteFileAsync(imagedate);
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Market");
            return actionState;
        }

        public async Task<ActionState> EditMarketAsync(EditMarketViewModel editMarketViewModel)
        {
            var actionState = new ActionState();
            var market = _mapper.Map<EditMarketViewModel, Market>(editMarketViewModel);
            _unitOfWork.MarketsRepository.Update(market);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                if (editMarketViewModel.Photo != null)
                {
                    var imageData = new SavingFileData()
                    {
                        File = editMarketViewModel.Photo,
                        fileName = market.Id.ToString(),
                        folderName = "Markets"
                    };
                    await _unitOfWork.FilesRepository.SaveFileAsync(imageData);
                }
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Market");
            return actionState;
        }

        public async Task<IEnumerable<MarketViewModel>> GetAllMarketsAsync()
        {
            var markets = await _unitOfWork.MarketsRepository.GetElementsAsync(market => true);

            var marketsViewModel = _mapper.Map<IEnumerable<Market>, IEnumerable<MarketViewModel>>(markets);

            return marketsViewModel;
        }

        public async Task<MarketViewModel> GetMarketDetailsAsync(int Id)
        {
            var market = await _unitOfWork.MarketsRepository.FindByIdAsync(Id);

            var marketViewModel = _mapper.Map<Market, MarketViewModel>(market);

            return marketViewModel;
        }

        public async Task<PagedResult<MarketViewModel>> GetDashboardMarketsAsync(PagingParameters pagingParameters)
        {
            var markets = await _unitOfWork.MarketsRepository.GetElementsWithOrderAsync(Market => true,
                       pagingParameters, Market => Market.Id, OrderingType.Descending);

            var marketsViewModel = markets.ToMappedPagedResult<Market, MarketViewModel>(_mapper);

            return marketsViewModel;
        }
    }
}
