using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Order.Handler.Extensions;
using Restaurant.Receipt.Handler.Extensions;
using Restaurant.ServiceBus.Implementation;

namespace Restaurant.ServiceBus
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceBus(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<GenericServiceBus>();

            services.AddRestaurantOrderHandler(configuration);
            services.AddRestaurrantReceiptHandler(configuration);
        }
    }
}
