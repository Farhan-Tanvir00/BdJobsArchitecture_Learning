using Microsoft.Extensions.DependencyInjection;
using Restaurant.Management.AggregateRoot.Aggrigates.Implementations;
using Restaurant.Management.AggregateRoot.Aggrigates.Interfaces;


namespace Restaurant.Management.AggregateRoot.Extensions
{
    public static class ServiceCollectionExtension
    {
        public static void AddRestaurantManagementAggrigateRoot(this IServiceCollection services)
        {
            services.AddScoped<IRestaurentAggrigator, RestaurantAggrigate>();
            //services.AddScoped(typeof(RestaurantAggrigate));
        }
    }
}
