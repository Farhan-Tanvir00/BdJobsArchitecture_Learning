using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Receipt.Repository.Implementation;
using Restaurant.Receipt.Repository.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Receipt.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurrantReceiptRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ReceiptDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("RestaurantDB_Test"))
                .EnableSensitiveDataLogging();
            });

            services.AddScoped<ReceiptRepository>();
        }
    }
}
