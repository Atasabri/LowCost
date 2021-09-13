using AutoMapper;
using LowCost.Domain.Models.BaseModels;
using LowCost.Infrastructure.Pagination;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading;

namespace LowCost.Business.Mapping
{
    public partial class AutoMapperProfile : Profile
    {
        private string localizedName
        {
            get
            {
                return CultureInfo.CurrentCulture.Name == "ar" ? "Name_AR" : "Name";
            }
        }


        public AutoMapperProfile()
        {
            CategoriesMapping();
            ProductsMapping();
            UsersMapping();
            NotificationsMapping();
            OrdersMapping();
            OffersMapping();
            SlidersMapping();
            BrandsMapping();
            MarketsMapping();
            ZonesMapping();

            // Dashboard Mapping
            DashboardUsersMapping();
            DashboardCategoriesMapping();
            DashboardBrandsMapping();
            DashboardMarketsMapping();
            DashboardSlidersMapping();
            DashboardOffersMapping();
            DashboardPromoCodesMapping();
            DashboardStatusesMapping();
            DashboardProductsMapping();
            DashboardOrdersMapping();
            DashboardSettingsMapping();
            DashboardStocksMapping();
            DashboardZonesMapping();
        }
    }
}
