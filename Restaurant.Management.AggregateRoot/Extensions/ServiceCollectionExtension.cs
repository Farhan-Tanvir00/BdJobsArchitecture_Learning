using Microsoft.Extensions.DependencyInjection;


namespace Restaurant.Management.AggregateRoot.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddRestaurantManagementAggrigateRoot(this IServiceCollection services)
        {
            services.AddScoped<RestaurantAggregateRoot>();
        }
    }
}
