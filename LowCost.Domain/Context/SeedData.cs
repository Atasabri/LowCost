using LowCost.Domain.Models;
using LowCost.Infrastructure.Helpers;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Domain.Context
{
    public static class SeedData
    {
        public static void Seed(ModelBuilder builder)
        {
            string AdminRoleId = Guid.NewGuid().ToString();
            string EditorRoleId = Guid.NewGuid().ToString();
            string UserRoleId = Guid.NewGuid().ToString();
            string DriverRoleId = Guid.NewGuid().ToString();
            string UserId = Guid.NewGuid().ToString();

            

            // Adding Admin Role
            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
                {
                new IdentityRole {
                              Id = AdminRoleId,
                              Name = Admin.AdminRoleName,
                              NormalizedName = Admin.AdminRoleName.ToUpper()
                          }
                 });
            // Adding Editor Role
            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
                {
                new IdentityRole {
                              Id = EditorRoleId,
                              Name = Admin.EditorRoleName,
                              NormalizedName = Admin.EditorRoleName.ToUpper()
                          }
                 });
            // Adding User Role
            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
                {
                new IdentityRole {
                              Id = UserRoleId,
                              Name = Constants.UserRoleName,
                              NormalizedName = Constants.UserRoleName.ToUpper()
                          }
                 });
            // Adding Driver Role
            builder.Entity<IdentityRole>().HasData(new List<IdentityRole>
                {
                new IdentityRole {
                              Id = DriverRoleId,
                              Name = Constants.DriverRoleName,
                              NormalizedName = Constants.DriverRoleName.ToUpper()
                          }
                 });

            // Adding First Admin User
            var hasher = new PasswordHasher<User>();
            builder.Entity<User>().HasData(
                new User
                {
                    Id = UserId,
                    UserName = Admin.FirstAdminUserName,
                    Email = Admin.FirstAdminEmail,
                    NormalizedUserName = Admin.FirstAdminUserName.ToUpper(),
                    PasswordHash = hasher.HashPassword(null, Admin.FirstAdminPassword),
                }
            );
            // Assign First Admin To Admin Role
            builder.Entity<IdentityUserRole<string>>().HasData(
                new IdentityUserRole<string>
                {
                    RoleId = AdminRoleId,
                    UserId = UserId
                }
            );

            // Adding Low Cost Offer As First Offer
            builder.Entity<Offer>().HasData(new Offer()
            {
                Id = Constants.LowCostOfferId,
                Name = Constants.LowCostOfferName,
                Name_AR = Constants.LowCostOfferName_Ar
            });
            // Adding Tax to App Settings
            builder.Entity<Settings>().HasData(new Settings()
            {
                Id = 1,
                Name = Constants.TaxKeyName,
                Key = Constants.TaxKey,
                Value = Constants.DefaultTaxValue.ToString(),
                Type = Type.GetTypeCode(Constants.DefaultTaxValue.GetType())
            });
            // Adding Visa Available to App Settings
            builder.Entity<Settings>().HasData(new Settings()
            {
                Id = 2,
                Name = Constants.VisaAvailableKeyName,
                Key = Constants.VisaAvailable,
                Value = Constants.DefaultVisaAvailable.ToString(),
                Type = Type.GetTypeCode(Constants.DefaultVisaAvailable.GetType())
            });
            // Adding Limit Price For Use Zero With Cost to App Settings
            builder.Entity<Settings>().HasData(new Settings()
            {
                Id = 3,
                Name = Constants.LimitPriceForUseZeroWithCostName,
                Key = Constants.LimitPriceForUseZeroWithCost,
                Value = Constants.DefaultLimitPriceForUseZeroWithCost.ToString(),
                Type = Type.GetTypeCode(Constants.DefaultLimitPriceForUseZeroWithCost.GetType())
            });
        }
    }
}
