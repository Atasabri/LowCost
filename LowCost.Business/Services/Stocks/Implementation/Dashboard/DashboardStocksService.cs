using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Stocks.Interfaces.Dashboard;
using LowCost.Infrastructure.DashboardViewModels.Stocks;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.Pagination;
using LowCost.Repo.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.Stocks.Implementation.Dashboard
{
    public class DashboardStocksService : IDashboardStocksService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DashboardStocksService(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this._unitOfWork = unitOfWork;
            this._mapper = mapper;
        }
        public async Task<CreateState> CreateStockAsync(AddStockViewModel addStockViewModel)
        {
            var createState = new CreateState();
            var stock = _mapper.Map<AddStockViewModel, Domain.Models.Stock>(addStockViewModel);

            await _unitOfWork.StocksRepository.CreateAsync(stock);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                createState.CreatedSuccessfully = true;
                return createState;
            }
            createState.ErrorMessages.Add("Can Not Create Stock");
            return createState;
        }

        public async Task<ActionState> DeleteStockAsync(int id)
        {
            var actionState = new ActionState();
            var stock = await _unitOfWork.StocksRepository.FindByIdAsync(id);
            if (stock == null)
            {
                actionState.ErrorMessages.Add("Can Not Find Stock !");
                return actionState;
            }
            _unitOfWork.StocksRepository.Delete(stock);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Delete Stock");
            return actionState;
        }

        public async Task<ActionState> EditStockAsync(EditStockViewModel editStockViewModel)
        {
            var actionState = new ActionState();
            var stock = _mapper.Map<EditStockViewModel, Domain.Models.Stock>(editStockViewModel);
            _unitOfWork.StocksRepository.Update(stock);
            var result = await _unitOfWork.SaveAsync() > 0;
            if (result)
            {
                actionState.ExcuteSuccessfully = true;
                return actionState;
            }
            actionState.ErrorMessages.Add("Can Not Edit Stock");
            return actionState;
        }

        public async Task<StockViewModel> GetStockDetailsAsync(int Id)
        {
            var stock = await _unitOfWork.StocksRepository.FindByIdAsync(Id);

            var stockViewModel = _mapper.Map<Domain.Models.Stock, StockViewModel>(stock);

            return stockViewModel;
        }
        public async Task<PagedResult<StockViewModel>> GetDashboardStocksAsync(PagingParameters pagingParameters)
        {
            var stocks = await _unitOfWork.StocksRepository.GetElementsAsync(Stock => true, pagingParameters);

            var stocksViewModel = stocks.ToMappedPagedResult<Domain.Models.Stock, StockViewModel>(_mapper);

            return stocksViewModel;
        }

        public async Task<IEnumerable<StockViewModel>> GetAllStocksAsync()
        {
            var stocks = await _unitOfWork.StocksRepository.GetElementsAsync(Stock => true);

            var stocksViewModel = _mapper.Map<IEnumerable<Domain.Models.Stock>, IEnumerable<StockViewModel>>(stocks);

            return stocksViewModel;
        }
    }
}
