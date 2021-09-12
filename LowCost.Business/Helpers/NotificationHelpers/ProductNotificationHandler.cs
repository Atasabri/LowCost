using LowCost.Domain.Models;
using LowCost.Infrastructure.Helpers;
using LowCost.Infrastructure.NotificationsHelpers;
using LowCost.Infrastructure.NotificationsHelpers.MobileNotificationModels;
using LowCost.Repo.UnitOfWork;
using LowCost.Resources;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Business.Helpers.NotificationHelpers
{
    public class ProductNotificationHandler
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IStringLocalizer<SharedResource> _stringLocalizer;
        public ProductNotificationHandler(IUnitOfWork unitOfWork, IStringLocalizer<SharedResource> stringLocalizer)
        {
            this._unitOfWork = unitOfWork;
            this._stringLocalizer = stringLocalizer;
        }


        public async Task AddingQuantityToStockNotify(int product_Id, List<int> stocks)
        {
            ProductNotificationState productNotificationState = new ProductNotificationState
            {
                Product_Id = product_Id,
                Stocks = stocks,
                Title_Key = "Product In Stock",
                Title_Arguments = new object[] { },
                Body_Key = "Product You Are Follow Is In Stock Now",
                Body_Arguments = new object[] { },
                Data = new {Product_Id = product_Id}
            };
            await NotifyFollowingUsersAsync(productNotificationState);
        }

        private async Task NotifyFollowingUsersAsync(ProductNotificationState productNotificationState)
        {
            var following = await _unitOfWork.ProductFollowingUsersRepository
                .GetElementsAsync(followUser => followUser.Product_Id == productNotificationState.Product_Id 
                && followUser.User.Stock_Id.HasValue 
                && productNotificationState.Stocks.Contains(followUser.User.Stock_Id.Value),
                string.Format("{0}", nameof(ProductFollowingUser.User)));

            foreach (int lang in Enum.GetValues(typeof(Languages)))
            {
                var languageUsers = following.Where(follower => follower.User.CurrentLangauge == (Languages)lang).Select(follower => follower.User).ToArray();

                if(languageUsers.Length > 0)
                {
                    var stringLocalizerUser = _stringLocalizer.WithCulture(new CultureInfo(Enum.GetName(typeof(Languages), lang)));

                    string messageTitle = stringLocalizerUser[productNotificationState.Title_Key, productNotificationState.Title_Arguments];
                    string messageBody = stringLocalizerUser[productNotificationState.Body_Key, productNotificationState.Body_Arguments];

                    var multiTopicsNotifyState = new MultiTopicsNotifyState()
                    {
                        Topics = languageUsers.Select(user => user.Id).ToArray(),
                        Title = messageTitle,
                        Body = messageBody,
                        NotificationHiddenData = productNotificationState.Data
                    };
                    // Sending Notification To Users Device 
                    await _unitOfWork.NotificationsRepository.NotifyMultiTopicsAsync(multiTopicsNotifyState);

                    // Adding Notifications To Users
                    foreach (var user in languageUsers)
                    {
                        await _unitOfWork.NotificationsRepository.CreateAsync(new Notification()
                        {
                            DateTime = DateTimeProvider.GetEgyptDateTime(),
                            Message = messageBody,
                            Product_Id = productNotificationState.Product_Id,
                            User_Id = user.Id
                        });
                    }
                }
            }
            await _unitOfWork.SaveAsync();
        }
    }
}
