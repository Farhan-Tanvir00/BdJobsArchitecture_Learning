using Microsoft.Extensions.DependencyInjection;
using Restaurant.Management.AggregateRoot.Aggrigates;


namespace Restaurant.Management.AggregateRoot.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddRestaurantManagementAggrigateRoot(this IServiceCollection services)
        {
            services.AddScoped<RestaurantAggrigate>();
        }
    }
}
