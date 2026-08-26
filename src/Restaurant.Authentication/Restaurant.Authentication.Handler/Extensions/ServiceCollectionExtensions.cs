using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Authentication.AggregateRoot.Extension;
using Restaurant.Authentication.Repository.Extensions;


namespace Restaurant.Authentication.Handler.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurantAuthenticationHandler(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRestaurantAuthenticationAggregateRoot();
            services.AddRestaurantAuthenticationRepository(configuration);
        }
    }
}
