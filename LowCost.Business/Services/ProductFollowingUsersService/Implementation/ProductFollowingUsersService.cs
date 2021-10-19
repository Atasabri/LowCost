using LowCost.Business.Services.ProductFollowingUsersService.Interfaces;
using LowCost.Domain.Models;
using LowCost.Infrastructure.Helpers;
using LowCost.Repo.UnitOfWork;
using LowCost.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Services.ProductFollowingUsersService.Implementation
{
    public class ProductFollowingUsersService : IProductFollowingUsersService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;

        public ProductFollowingUsersService(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> stringLocalizer)
        {
            this._unitOfWork = unitOfWork;
            this._stringLocalizer = stringLocalizer;
        }


        public async Task<ActionState> FollowProductAsync(int product_Id)
        {
            var actionState = new ActionState();
            // Get Current User Id
            var currentUserid = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();
            // Adding User To Product Following Users
            var following = await _unitOfWork.ProductFollowingUsersRepository
                                 .FindElementAsync(follower => follower.Product_Id == product_Id && follower.User_Id == currentUserid);
           
            if(following == null)
            {
                following = new ProductFollowingUser
                {
                    Product_Id = product_Id,
                    User_Id = currentUserid
                };
                await _unitOfWork.ProductFollowingUsersRepository.CreateAsync(following);
                var result = await _unitOfWork.SaveAsync() > 0;
                if (result)
                {
                    actionState.ExcuteSuccessfully = true;
                }
            }
            else
            {
                actionState.ErrorMessages.Add(_stringLocalizer["You Already Follow This Product"]);
            }
            return actionState;
        }

        public async Task<ActionState> UnFollowProductAsync(int product_Id)
        {
            var actionState = new ActionState();
            // Get Current User Id
            var currentUserid = await _unitOfWork.CurrentUserRepository.GetCurrentUserId();
            // Deleting User From Product Following Users
            var following = await _unitOfWork.ProductFollowingUsersRepository
                                 .FindElementAsync(follower => follower.Product_Id == product_Id && follower.User_Id == currentUserid);
           
            if(following != null)
            {
                _unitOfWork.ProductFollowingUsersRepository.Delete(following);
                var result = await _unitOfWork.SaveAsync() > 0;
                if (result)
                {
                    actionState.ExcuteSuccessfully = true;
                }
            }
            else
            {
                actionState.ErrorMessages.Add(_stringLocalizer["You Are Not Follow This Product"]);
            }

            return actionState;
        }
    }
}
