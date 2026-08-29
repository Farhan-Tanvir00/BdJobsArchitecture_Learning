using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Order.Repository.Implementations;
using Restaurant.Order.Repository.Persistance;


namespace Restaurant.Order.Repository.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurantOrderRepository(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<RestaurantOrderDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("RestaurantDB_Test"))
                .EnableSensitiveDataLogging();
            });

            services.AddScoped<OrderRepository>();
        }
    }
}
