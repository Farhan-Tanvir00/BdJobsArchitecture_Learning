using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Management.AggregateRoot.Extensions;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.DTO.DTO;
using Restaurant.Management.DTO.Queries;
using Restaurant.Management.Handler.CommandHandlers;
using Restaurant.Management.Handler.QueryHandlers;
using Restaurant.Management.Repository.Extensions;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;


namespace Restaurant.Management.Handler.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurantManagementHandler(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICommandHandler<CreateRestaurantCommand>, CreateRestaurantCommandHandler>();
            services.AddScoped<ICommandHandler<DeleteRestaurantCommand>, DeleteRestaurantCommandHandler>();
            services.AddScoped<ICommandHandler<UpdateRestaurantCommand>, UpdateRestaurantCommandHandler>();
            services.AddScoped<ICommandHandler<ActiveDeliveryRestaurantCommand>, ActiveDeliveryRestaurantCommandHandler>();

            services.AddScoped<IQueryHandler<GetAllRestaurantQuery, ApiResponse<List<RestaurantDTO>>>, GetAllRestaurantQueryHandler>();
            services.AddScoped<IQueryHandler<GetOneRestaurantQuery, ApiResponse<RestaurantDTO>>, GetOneRestaurantQueryHandler>();

            services.AddRestaurantManagementAggrigateRoot();
            services.AddRestaurantManagementRepository(configuration);
        }
    }
}
