using Microsoft.Extensions.DependencyInjection;

namespace Restaurant.Order.AggregateRoot.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurantOrderAggregateRoot(this IServiceCollection service)
        {
            service.AddScoped<OrderAggregateRoot>();
        }
    }
}
