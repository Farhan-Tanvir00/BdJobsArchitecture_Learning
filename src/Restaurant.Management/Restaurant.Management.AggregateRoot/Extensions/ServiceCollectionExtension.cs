using FluentValidation;
using Microsoft.Extensions.DependencyInjection;


namespace Restaurant.Management.AggregateRoot.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddRestaurantManagementAggrigateRoot(this IServiceCollection services)
        {
            var ApplicationAssembly = typeof(ServiceCollectionExtension).Assembly;

            services.AddScoped<RestaurantAggregateRoot>();

            services.AddValidatorsFromAssembly(ApplicationAssembly);
        }
    }
}
