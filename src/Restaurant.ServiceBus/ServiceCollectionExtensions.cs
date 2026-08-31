using Microsoft.Extensions.DependencyInjection;
using Restaurant.ServiceBus.Implementation;

namespace Restaurant.ServiceBus
{
    public static class ServiceCollectionExtensions
    {
        public static void AddServiceBus(this IServiceCollection services)
        {
            services.AddScoped<GenericServiceBus>();
        }
    }
}
