using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Management.Repository.Implementations;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Repository.Persistance;

namespace Restaurant.Management.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurantManagementRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("RestaurantDB_Test"))
                .EnableSensitiveDataLogging();
            });

            services.AddScoped<IUnitOfWork, UnitOfWork>();
        }
    }
}
