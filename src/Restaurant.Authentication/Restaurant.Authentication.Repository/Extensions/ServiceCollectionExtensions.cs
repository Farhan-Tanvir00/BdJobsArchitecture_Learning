using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Authentication.Repository.Persistance;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Authentication.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurantAuthenticationRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantAuthenticationDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("RestaurantDB_Test"))
                .EnableSensitiveDataLogging();
            });
        }   
    }
}
