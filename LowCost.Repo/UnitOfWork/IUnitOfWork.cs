using LowCost.Repo.Repositories.Interfaces.Brands;
using LowCost.Repo.Repositories.Interfaces.Categories;
using LowCost.Repo.Repositories.Interfaces.Files;
using LowCost.Repo.Repositories.Interfaces.Markets;
using LowCost.Repo.Repositories.Interfaces.Notifications;
using LowCost.Repo.Repositories.Interfaces.Offers;
using LowCost.Repo.Repositories.Interfaces.Orders;
using LowCost.Repo.Repositories.Interfaces.OrderSizeDelivery;
using LowCost.Repo.Repositories.Interfaces.ProductFollowingUsers;
using LowCost.Repo.Repositories.Interfaces.Products;
using LowCost.Repo.Repositories.Interfaces.PromoCodes;
using LowCost.Repo.Repositories.Interfaces.Settings;
using LowCost.Repo.Repositories.Interfaces.Sliders;
using LowCost.Repo.Repositories.Interfaces.SMSCodes;
using LowCost.Repo.Repositories.Interfaces.StockProducts;
using LowCost.Repo.Repositories.Interfaces.Stocks;
using LowCost.Repo.Repositories.Interfaces.User;
using LowCost.Repo.Repositories.Interfaces.Zoons;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace LowCost.Repo.UnitOfWork
{
    public interface IUnitOfWork
    {
        // Zoons Repositories
        IZoonsRepository ZoonsRepository { get; }
        // Stocks Repositories
        IStocksRepository StocksRepository { get; }
        IStockProductsRepository StockProductsRepository { get; }

        // Brands Repositories
        IBrandsRepository BrandsRepository { get; }

        // Sliders Repositories
        ISlidersRepository SlidersRepository { get; }

        // Categories Repositories
        ICategoriesRepository CategoriesRepository { get; }
        IMainCategoriesRepository MainCategoriesRepository { get; }
        ISubCategoriesRepository SubCategoriesRepository { get; }

        // Offers Repositories
        IOffersRepository OffersRepository { get; }


        // Markets Repositories
        IMarketsRepository MarketsRepository { get; }


        //Notifications Repositories
        INotificationsRepository NotificationsRepository { get; }


        // Orders Repositories
        IOrderDetailsRepository OrderDetailsRepository { get; }
        IOrdersRepository OrdersRepository { get; }
        IOrderStatusesRepository OrderStatusesRepository { get; }
        IStatusesRepository StatusesRepository { get; }


        //Products Repositories
        IPricesRepository PricesRepository { get; }
        IProductFollowingUsersRepository ProductFollowingUsersRepository { get; }
        IProductsRepository ProductsRepository { get; }

        // Promo Codes Repositories
        IPromoCodesRepository PromoCodesRepository { get; }


        // User Repositories
        IAddressesRepository AddressesRepository { get; }
        IFavoritesRepository FavoritesRepository { get; }
        IPaymentMethodsRepository PaymentMethodsRepository { get; }
        IUsersRepository UsersRepository { get; }


        // Files Repositories
        IFilesRepository FilesRepository { get; }

        // Settings Repositories
        ISettingsRepository SettingsRepository { get; }
        IOrderSizeDeliveryRepository OrderSizeDeliveryRepository { get; }

        // Verification Repositories
        ISMSCodeRepository SMSCodeRepository { get; }





        /// <summary>
        /// Save Changes To Database
        /// </summary>
        int Save();
        /// <summary>
        /// Save Changes To Database Asynchronous
        /// </summary>
        Task<int> SaveAsync();
    }
}
