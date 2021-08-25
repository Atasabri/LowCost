using LowCost.Domain.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace LowCost.Domain.Context
{
    public class DB : IdentityDbContext<User>
    {
        public DB()
        {
        }

        public DB(DbContextOptions<DB> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
        public DbSet<MainCategory> MainCategories { get; set; }
        public DbSet<Brand> Brands { get; set; }
        public DbSet<SubCategory> SubCategories { get; set; }
        public DbSet<Offer> Offers { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<Market> Markets { get; set; }
        public DbSet<PromoCode> PromoCodes { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
        public DbSet<Statuses> Statuses { get; set; }
        public DbSet<OrderStatus> OrderStatuses { get; set; }
        public DbSet<Prices> Prices { get; set; }
        public DbSet<Notification> Notifications { get; set; }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Favorites> Favorites { get; set; }
        public DbSet<Slider> Sliders { get; set; }
        public DbSet<Settings> Settings { get; set; }
        public DbSet<SmsCode> SmsCodes { get; set; }



        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            IConfigurationRoot configuration = new ConfigurationBuilder()
            .SetBasePath(AppContext.BaseDirectory)
            .AddJsonFile("settings.json")
            .Build();
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer(configuration.GetConnectionString("DB"));
            }
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Seed Data
            SeedData.Seed(builder);
        }
    }
}
