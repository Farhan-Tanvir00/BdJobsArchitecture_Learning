using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Restaurant.Order.AggregateRoot.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurantOrderAggregateRoot(this IServiceCollection service)
        {
            var ApplicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

            service.AddScoped<OrderAggregateRoot>();

            service.AddValidatorsFromAssembly(ApplicationAssembly);
        }
    }
}
