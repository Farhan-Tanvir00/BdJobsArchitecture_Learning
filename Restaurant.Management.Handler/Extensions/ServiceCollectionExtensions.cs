using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Management.AggregateRoot.Extensions;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.Handler.CommandHandlers;
using Restaurant.Management.Repository.Extensions;
using Restaurant.Management.Shared.Interfaces.Commands;


namespace Restaurant.Management.Handler.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurantManagementHandler(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICommandHandler<CreateRestaurantCommand>, CreateRestaurantCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteRestaurantCommand>, DeleteRestaurantCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateRestaurantCommand>, UpdateRestaurantCommandHandler>();

            services.AddRestaurantManagementAggrigateRoot();
            services.AddRestaurantManagementRepository(configuration);
        }
    }
}
