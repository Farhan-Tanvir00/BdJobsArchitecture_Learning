using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Authentication.AggregateRoot.Extension;
using Restaurant.Authentication.DTO.Commands;
using Restaurant.Authentication.Handler.CommandHandlers;
using Restaurant.Authentication.Handler.Services;
using Restaurant.Authentication.Repository.Extensions;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;


namespace Restaurant.Authentication.Handler.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurantAuthenticationHandler(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddRestaurantAuthenticationAggregateRoot();
            services.AddRestaurantAuthenticationRepository(configuration);
            services.AddScoped<ITokenService, TokenService>();

            services.AddScoped<ICommandHandler<UserLoginCommand>, UserLoginCommandHandler>();
            services.AddScoped<ICommandHandler<UserRegisterCommand>,  UserRegisterCommandHandler>();
        }
    }
}
