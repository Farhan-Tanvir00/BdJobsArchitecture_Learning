using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Order.AggregateRoot.Extensions;
using Restaurant.Order.DTO.Commands;
using Restaurant.Order.Handler.CommandHandlers;
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

            service.AddRestaurantOrderAggregateRoot();
            service.AddRestaurantOrderRepository(configuration);
        }
    }
}
