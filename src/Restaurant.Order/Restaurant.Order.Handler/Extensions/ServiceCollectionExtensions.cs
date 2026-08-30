using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Order.AggregateRoot.Extensions;
using Restaurant.Order.DTO.Commands;
using Restaurant.Order.DTO.DTO;
using Restaurant.Order.DTO.Query;
using Restaurant.Order.Handler.CommandHandlers;
using Restaurant.Order.Handler.QueryHandler;
using Restaurant.Order.Repository.Extensions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Order.Handler.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurantOrderHandler(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<ICommandHandler<CreateOrderCommand>, CreateOrderCommandHandler>();
            service.AddScoped<IQueryHandler<GetOrderByIdQuery, ApiResponse<OrderDto>>, GetOrderByIdQueryHandler>();

            service.AddRestaurantOrderAggregateRoot();
            service.AddRestaurantOrderRepository(configuration);
        }
    }
}
