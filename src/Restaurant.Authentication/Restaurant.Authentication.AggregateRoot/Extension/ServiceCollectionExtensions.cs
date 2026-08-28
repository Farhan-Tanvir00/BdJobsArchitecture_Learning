using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace Restaurant.Authentication.AggregateRoot.Extension
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurantAuthenticationAggregateRoot(this IServiceCollection services)
        {
            var ApplicationAssembly = typeof(ServiceCollectionExtensions).Assembly;

            services.AddScoped<UserAggregateRoot>();
            services.AddScoped<RoleAggregateRoot>();

            services.AddValidatorsFromAssembly(ApplicationAssembly);
        }
    }
}
