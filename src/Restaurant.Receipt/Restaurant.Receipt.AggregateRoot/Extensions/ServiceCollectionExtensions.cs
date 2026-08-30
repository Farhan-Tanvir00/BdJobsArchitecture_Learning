using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Receipt.AggregateRoot.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddAddRestaurrantReceiptAggregateRoot(this IServiceCollection service)
        {
            service.AddScoped<RestaurantReceiptAggregateRoot>();
        }
    }
}
