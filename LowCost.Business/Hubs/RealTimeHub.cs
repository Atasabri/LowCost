using LowCost.Infrastructure.Helpers;
using LowCost.Repo.UnitOfWork;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Hubs
{
    public class RealTimeHub : Hub
    {
        private readonly IUnitOfWork _unitOfWork;

        public RealTimeHub(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public override async Task OnConnectedAsync()
        {
            var user = await _unitOfWork.UsersRepository.GetCurrentDashboardAdminUser();
            if(user.Stock_Id == null)
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, Constants.AccessAllDashboardStocksDataGroupName);
            }
            else
            {
                await Groups.AddToGroupAsync(Context.ConnectionId, user.Stock_Id.ToString());
            }
            await base.OnConnectedAsync();
        }
    }
}
