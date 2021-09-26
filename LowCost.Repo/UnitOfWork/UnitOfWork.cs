using LowCost.Repo.Repositories.Interfaces.Brands;
using LowCost.Repo.Repositories.Interfaces.Categories;
using LowCost.Repo.Repositories.Interfaces.Markets;
using LowCost.Repo.Repositories.Interfaces.Notifications;
using LowCost.Repo.Repositories.Interfaces.Orders;
using LowCost.Repo.Repositories.Interfaces.Products;
using LowCost.Repo.Repositories.Interfaces.PromoCodes;
using LowCost.Repo.Repositories.Interfaces.User;
using LowCost.Repo.Repositories.Implementation.Brands;
using LowCost.Repo.Repositories.Implementation.Categories;
using LowCost.Repo.Repositories.Implementation.Markets;
using LowCost.Repo.Repositories.Implementation.Notifications;
using LowCost.Repo.Repositories.Implementation.Orders;
using LowCost.Repo.Repositories.Implementation.Products;
using LowCost.Repo.Repositories.Implementation.PromoCodes;
using LowCost.Repo.Repositories.Implementation.User;
using LowCost.Domain.Context;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using LowCost.Domain.Models;
using LowCost.Repo.Repositories.Interfaces.Offers;
using LowCost.Repo.Repositories.Implementation.Offers;
using LowCost.Repo.Repositories.Interfaces.Sliders;
using LowCost.Repo.Repositories.Implementation.Sliders;
using LowCost.Repo.Repositories.Interfaces.Files;
using LowCost.Repo.Repositories.Implementation.Files;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Options;
using LowCost.Infrastructure.AppSettings;
using LowCost.Repo.Repositories.Interfaces.Settings;
using LowCost.Repo.Repositories.Implementation.Settings;
using LowCost.Repo.Repositories.Interfaces.SMSCodes;
using LowCost.Repo.Repositories.Implementation.SMSCodes;
using LowCost.Repo.Repositories.Interfaces.ProductFollowingUsers;
using LowCost.Repo.Repositories.Implementation.ProductFollowingUsers;
using LowCost.Repo.Repositories.Interfaces.Zones;
using LowCost.Repo.Repositories.Interfaces.Stocks;
using LowCost.Repo.Repositories.Interfaces.StockProducts;
using LowCost.Repo.Repositories.Interfaces.OrderSizeDelivery;
using LowCost.Repo.Repositories.Implementation.Zones;
using LowCost.Repo.Repositories.Implementation.Stocks;
using LowCost.Repo.Repositories.Implementation.StockProducts;
using LowCost.Repo.Repositories.Implementation.OrderSizeDelivery;

namespace LowCost.Repo.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DB _context;
        private readonly IHttpContextAccessor _accessor;
        private readonly UserManager<User> _userManager;
        private readonly IHostingEnvironment _hostingEnvironment;
        private readonly AppSettings _appSettings;

        IBrandsRepository brandsRepository;
        ISlidersRepository slidersRepository;
        IZonesRepository zonesRepository;
        IStocksRepository stocksRepository;
        IStockProductsRepository stockProductsRepository;
        ICategoriesRepository categoriesRepository;
        IMainCategoriesRepository mainCategoriesRepository;
        ISubCategoriesRepository subCategoriesRepository;
        IOffersRepository offersRepository;
        IMarketsRepository marketsRepository;
        INotificationsRepository notificationsRepository;
        IOrderDetailsRepository orderDetailsRepository;
        IOrdersRepository ordersRepository;
        IOrderStatusesRepository orderStatusesRepository;
        IStatusesRepository statusesRepository;
        IPricesRepository pricesRepository;
        IProductsRepository productsRepository;
        IProductFollowingUsersRepository productFollowingUsersRepository;
        IPromoCodesRepository promoCodesRepository;
        IAddressesRepository addressesRepository;
        IFavoritesRepository favoritesRepository;
        IPaymentMethodsRepository paymentMethodsRepository;
        ICurrentUserRepository currentUserRepository;
        IFilesRepository filesRepository;
        ISettingsRepository settingsRepository;
        IOrderSizeDeliveryRepository orderSizeDeliveryRepository;
        ISMSCodeRepository smsCodeRepository;


        public IBrandsRepository BrandsRepository
        {
            get
            {
                if (brandsRepository == null)
                {
                    brandsRepository = new BrandsRepository(_context);
                }
                return brandsRepository;
            }
        }

        public ISlidersRepository SlidersRepository
        {
            get
            {
                if (slidersRepository == null)
                {
                    slidersRepository = new SlidersRepository(_context);
                }
                return slidersRepository;
            }
        }

        public IZonesRepository ZonesRepository
        {
            get
            {
                if (zonesRepository == null)
                {
                    zonesRepository = new ZonesRepository(_context);
                }
                return zonesRepository;
            }
        }

        public IStocksRepository StocksRepository
        {
            get
            {
                if (stocksRepository == null)
                {
                    stocksRepository = new StocksRepository(_context);
                }
                return stocksRepository;
            }
        }

        public IStockProductsRepository StockProductsRepository
        {
            get
            {
                if (stockProductsRepository == null)
                {
                    stockProductsRepository = new StockProductsRepository(_context);
                }
                return stockProductsRepository;
            }
        }

        public ICategoriesRepository CategoriesRepository
        {
            get
            {
                if (categoriesRepository == null)
                {
                    categoriesRepository = new CategoriesRepository(_context);
                }
                return categoriesRepository;
            }
        }

        public IMainCategoriesRepository MainCategoriesRepository
        {
            get
            {
                if (mainCategoriesRepository == null)
                {
                    mainCategoriesRepository = new MainCategoriesRepository(_context);
                }
                return mainCategoriesRepository;
            }
        }

        public ISubCategoriesRepository SubCategoriesRepository
        {
            get
            {
                if (subCategoriesRepository == null)
                {
                    subCategoriesRepository = new SubCategoriesRepository(_context);
                }
                return subCategoriesRepository;
            }
        }

        public IOffersRepository OffersRepository
        {
            get
            {
                if (offersRepository == null)
                {
                    offersRepository = new OffersRepository(_context);
                }
                return offersRepository;
            }
        }

        public IMarketsRepository MarketsRepository
        {
            get
            {
                if (marketsRepository == null)
                {
                    marketsRepository = new MarketsRepository(_context);
                }
                return marketsRepository;
            }
        }

        public INotificationsRepository NotificationsRepository
        {
            get
            {
                if (notificationsRepository == null)
                {
                    notificationsRepository = new NotificationsRepository(_context, _appSettings);
                }
                return notificationsRepository;
            }
        }

        public IOrderDetailsRepository OrderDetailsRepository
        {
            get
            {
                if (orderDetailsRepository == null)
                {
                    orderDetailsRepository = new OrderDetailsRepository(_context);
                }
                return orderDetailsRepository;
            }
        }

        public IOrdersRepository OrdersRepository
        {
            get
            {
                if (ordersRepository == null)
                {
                    ordersRepository = new OrdersRepository(_context);
                }
                return ordersRepository;
            }
        }

        public IOrderStatusesRepository OrderStatusesRepository
        {
            get
            {
                if (orderStatusesRepository == null)
                {
                    orderStatusesRepository = new OrderStatusesRepository(_context);
                }
                return orderStatusesRepository;
            }
        }

        public IStatusesRepository StatusesRepository
        {
            get
            {
                if (statusesRepository == null)
                {
                    statusesRepository = new StatusesRepository(_context);
                }
                return statusesRepository;
            }
        }

        public IPricesRepository PricesRepository
        {
            get
            {
                if (pricesRepository == null)
                {
                    pricesRepository = new PricesRepository(_context);
                }
                return pricesRepository;
            }
        }

        public IProductFollowingUsersRepository ProductFollowingUsersRepository
        {
            get
            {
                if (productFollowingUsersRepository == null)
                {
                    productFollowingUsersRepository = new ProductFollowingUsersRepository(_context);
                }
                return productFollowingUsersRepository;
            }
        }

        public IProductsRepository ProductsRepository
        {
            get
            {
                if (productsRepository == null)
                {
                    productsRepository = new ProductsRepository(_context);
                }
                return productsRepository;
            }
        }

        public IPromoCodesRepository PromoCodesRepository
        {
            get
            {
                if (promoCodesRepository == null)
                {
                    promoCodesRepository = new PromoCodesRepository(_context);
                }
                return promoCodesRepository;
            }
        }

        public IAddressesRepository AddressesRepository
        {
            get
            {
                if (addressesRepository == null)
                {
                    addressesRepository = new AddressesRepository(_context);
                }
                return addressesRepository;
            }
        }

        public IFavoritesRepository FavoritesRepository
        {
            get
            {
                if (favoritesRepository == null)
                {
                    favoritesRepository = new FavoritesRepository(_context);
                }
                return favoritesRepository;
            }
        }

        public IPaymentMethodsRepository PaymentMethodsRepository
        {
            get
            {
                if (paymentMethodsRepository == null)
                {
                    paymentMethodsRepository = new PaymentMethodsRepository(_context);
                }
                return paymentMethodsRepository;
            }
        }

        public ICurrentUserRepository CurrentUserRepository
        {
            get
            {
                if (currentUserRepository == null)
                {
                    currentUserRepository = new CurrentUserRepository(_accessor, _userManager);
                }
                return currentUserRepository;
            }
        }

        public IFilesRepository FilesRepository
        {
            get
            {
                if (filesRepository == null)
                {
                    filesRepository = new FilesRepository(_hostingEnvironment);
                }
                return filesRepository;
            }
        }

        public ISettingsRepository SettingsRepository
        {
            get
            {
                if (settingsRepository == null)
                {
                    settingsRepository = new SettingsRepository(_context);
                }
                return settingsRepository;
            }
        }

        public IOrderSizeDeliveryRepository OrderSizeDeliveryRepository
        {
            get
            {
                if (orderSizeDeliveryRepository == null)
                {
                    orderSizeDeliveryRepository = new OrderSizeDeliveryRepository(_context);
                }
                return orderSizeDeliveryRepository;
            }
        }

        public ISMSCodeRepository SMSCodeRepository
        {
            get
            {
                if (smsCodeRepository == null)
                {
                    smsCodeRepository = new SMSCodeRepository(_context);
                }
                return smsCodeRepository;
            }
        }


        public UnitOfWork(DB context, IHttpContextAccessor accessor,
            UserManager<User> userManager,
            IHostingEnvironment hostingEnvironment,
            IOptions<AppSettings> appSettings)
        {
            _context = context;
            this._accessor = accessor;
            this._userManager = userManager;
            this._hostingEnvironment = hostingEnvironment;
            this._appSettings = appSettings.Value;
        }

        public int Save()
        {
            return _context.SaveChanges();
        }

        public async Task<int> SaveAsync()
        {
            return await _context.SaveChangesAsync();
        }
    }
}
