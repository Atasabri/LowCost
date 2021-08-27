using AutoMapper;
using LowCost.Business.Mapping;
using LowCost.Business.Services.Categories.Implementation;
using LowCost.Business.Services.Categories.Interfaces;
using LowCost.Business.Services.Identity.Implementation;
using LowCost.Business.Services.Identity.Interfaces;
using LowCost.Business.Services.Identity.Implementation.Dashboard;
using LowCost.Business.Services.Identity.Interfaces.Dashboard;
using LowCost.Business.Services.Notifications.Implementation;
using LowCost.Business.Services.Notifications.Interfaces;
using LowCost.Business.Services.Offers.Implementation;
using LowCost.Business.Services.Offers.Interfaces;
using LowCost.Business.Services.Orders.Implementation;
using LowCost.Business.Services.Orders.Interfaces;
using LowCost.Business.Services.Products.Implementation;
using LowCost.Business.Services.Products.Interfaces;
using LowCost.Business.Services.Search.Implementation;
using LowCost.Business.Services.Search.Interfaces;
using LowCost.Business.Services.Sliders.Implementation;
using LowCost.Business.Services.Sliders.Interfaces;
using LowCost.Business.Services.User.Implementation;
using LowCost.Business.Services.User.Interfaces;
using LowCost.Business.Services.User.Implementation.Dashboard;
using LowCost.Business.Services.User.Interfaces.Dashboard;
using LowCost.Domain.Context;
using LowCost.Domain.Models;
using LowCost.Infrastructure.BaseService;
using LowCost.Infrastructure.Helpers;
using LowCost.Repo.UnitOfWork;
using LowCost.Resources.Localization;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Localization.Routing;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Razor;
using Microsoft.AspNetCore.Routing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;
using LowCost.Business.Services.Categories.Interfaces.Dashboard;
using LowCost.Business.Services.Categories.Implementation.Dashboard;
using LowCost.Business.Services.Brands.Implementation;
using LowCost.Business.Services.Brands.Interfaces;
using LowCost.Business.Services.Markets.Implementation;
using LowCost.Business.Services.Markets.Interfaces;
using LowCost.Business.Services.Brands.Interfaces.Dashboard;
using LowCost.Business.Services.Brands.Implementation.Dashboard;
using LowCost.Business.Services.Markets.Interfaces.Dashboard;
using LowCost.Business.Services.Sliders.Interfaces.Dashboard;
using LowCost.Business.Services.Offers.Interfaces.Dashboard;
using LowCost.Business.Services.Markets.Implementation.Dashboard;
using LowCost.Business.Services.Sliders.Implementation.Dashboard;
using LowCost.Business.Services.Offers.Implementation.Dashboard;
using LowCost.Business.Services.PromoCodes.Interfaces.Dashboard;
using LowCost.Business.Services.PromoCodes.Implementation.Dashboard;
using LowCost.Business.Services.Statuses.Interfaces.Dashboard;
using LowCost.Business.Services.Statuses.Implementation.Dashboard;
using LowCost.Business.Services.Products.Implementation.Dashboard;
using LowCost.Business.Services.Products.Interfaces.Dashboard;
using LowCost.Business.Services.Orders.Interfaces.Dashboard;
using LowCost.Business.Services.Orders.Implementation.Dashboard;
using LowCost.Infrastructure.Hubs;
using LowCost.Business.Services.Verification.Interfaces;
using LowCost.Business.Services.Verification.Implementation;
using LowCost.Infrastructure.AppSettings;
using LowCost.Resources;
using LowCost.Business.Services.Settings.Interfaces.Dashboard;
using LowCost.Business.Services.Settings.Implementation.Dashboard;
using LowCost.Business.Helpers;
using LowCost.Business.Services.Settings.Implementation;
using LowCost.Business.Services.Settings.Interfaces;
using LowCost.Business.Services.Search.Implementation.Dashboard;
using LowCost.Business.Services.Search.Interfaces.Dashboard;

namespace LowCost.Web
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<AppSettings>(Configuration);

            services.AddAutoMapper(typeof(AutoMapperProfile).Assembly);
            services.AddSignalR();
            //Adding Localization Service
            services.AddLocalization(opts =>
            {
                opts.ResourcesPath = "Resources";
            });

            //Add Mvc To Dependency Injection Container With Localization Pipline Middleware Attribute
            services.AddControllersWithViews()
                    .AddViewLocalization(opts => { opts.ResourcesPath = "Resources"; })
                    .AddViewLocalization(LanguageViewLocationExpanderFormat.Suffix)
                    .AddDataAnnotationsLocalization(options => {
                        options.DataAnnotationLocalizerProvider = (type, factory) =>
                            factory.Create(typeof(SharedResource));
                    });



            // Localization Configuration
            var supportedCultures = new[]
                         {
                          new CultureInfo("en"),
                          new CultureInfo("ar"),
                         };

            var options = new RequestLocalizationOptions()
            {
                DefaultRequestCulture = new RequestCulture(culture: "en", uiCulture: "en"),
                SupportedCultures = supportedCultures,
                SupportedUICultures = supportedCultures
            };
            options.RequestCultureProviders = new[]
            {
                 new RouteDataRequestCultureProvider() { Options = options }
            };
            services.AddSingleton(options);


            //Adding Default System Identity
            services.AddIdentity<User, IdentityRole>()
                .AddErrorDescriber<LocalizedIdentityErrorDescriber>()
                .AddEntityFrameworkStores<DB>()
                .AddDefaultTokenProviders();

            services.ConfigureApplicationCookie(options => options.LoginPath = "/Account/Login");

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "LowCost", Version = "v1" });
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = @"JWT Authorization Header Using The Bearer Scheme. \r\n\r\n 
                      Enter 'Bearer' [space] And Ahen Your Token in The Text Input Below.
                      \r\n\r\nExample: 'Bearer 12345abcdef'",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement()
                {
                     {
                         new OpenApiSecurityScheme
                         {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            },
                            Scheme = "oauth2",
                            Name = "Bearer",
                            In = ParameterLocation.Header,
                         },
                         new List<string>()
                     }
                });
            });

            //############### Adding Authentication And Authorization Service ##################
            // Adding Authentication  
            services.AddAuthentication()
            .AddCookie(options => options.SlidingExpiration = true)

            // Adding Jwt Bearer  
            .AddJwtBearer(options =>
            {
                options.SaveToken = true;
                options.RequireHttpsMetadata = false;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Constants.Audiance,
                    ValidIssuer = Constants.Issuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Constants.Secret))
                };
            });
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            });
            // Configure CORS
            services.AddCors(c =>
            {
                c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
            });

            services.AddTransient<ICategoriesService, CategoriesService>();
            services.AddTransient<IProductsService, ProductsService>();
            services.AddTransient<ISearchService, SearchService>();
            services.AddTransient<IAuthenticationService, AuthenticationService>();
            services.AddTransient<IDriverAuthenticationService, DriverAuthenticationService>();
            services.AddTransient<IVerificationService, VerificationService>();
            services.AddTransient<IUserService, UserService>();
            services.AddTransient<IDriverService, DriverService>();
            services.AddTransient<INotificationsService, NotificationsService>();
            services.AddTransient<IFavoritesService, FavoritesService>();
            services.AddTransient<IAddressService, AddressService>();
            services.AddTransient<IPaymentMethodsService, PaymentMethodsService>();
            services.AddTransient<IOrdersService, OrdersService>();
            services.AddTransient<IOffersService, OffersService>();
            services.AddTransient<ISlidersService, SlidersService>();
            services.AddTransient<IBrandsService, BrandsService>();
            services.AddTransient<IMarketsService, MarketsService>();
            services.AddTransient<ISettingsService, SettingsService>();


            // Dashboard Dpendency Injection
            services.AddTransient<IDashboardAuthenticationService, DashboardAuthenticationService>();
            services.AddTransient<IDashboardUserService, DashboardUserService>();
            services.AddTransient<IDashboardDriverService, DashboardDriverService>();
            services.AddTransient<IDashboardMainCategoriesService, DashboardMainCategoriesService>();
            services.AddTransient<IDashboardCategoriesService, DashboardCategoriesService>();
            services.AddTransient<IDashboardSubCategoriesService, DashboardSubCategoriesService>();
            services.AddTransient<IDashboardBrandsService, DashboardBrandsService>();
            services.AddTransient<IDashboardMarketsService, DashboardMarketsService>();
            services.AddTransient<IDashboardSlidersService, DashboardSlidersService>();
            services.AddTransient<IDashboardOffersService, DashboardOffersService>();
            services.AddTransient<IDashboardPromoCodeService, DashboardPromoCodeService>();
            services.AddTransient<IDashboardStatusesService, DashboardStatusesService>();
            services.AddTransient<IDashboardProductsService, DashboardProductsService>();
            services.AddTransient<IDashboardOrdersService, DashboardOrdersService>();
            services.AddTransient<IDashboardSettingsService, DashboardSettingsService>();
            services.AddTransient<IDashboardSearchService, DashboardSearchService>();

            services.AddTransient<AuthenticationHandler>();
            services.AddTransient<NotificationHandler>();

            services.AddHttpContextAccessor();
            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<DB>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            app.UseHttpsRedirection();

            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "LowCost");
                c.RoutePrefix = "api";
            });

            // Add Localization Middleware
            var options = app.ApplicationServices.GetService<IOptions<RequestLocalizationOptions>>();
            app.UseRequestLocalization(options.Value);


            app.UseRouting();

            app.UseAuthentication();

            app.UseStaticFiles();

            app.UseAuthorization();

            app.UseCors(options => options.AllowAnyOrigin());

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                     name: "default",
                     pattern: "{controller=Home}/{action=Index}/{id?}");
                endpoints.MapHub<RealTimeHub>("/RealTimeData");
            });
        }
    }
}
