using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Orchestrator.DTO.Command;
using Restaurant.Orchestrator.Handler.CommandHandlers;
using Restaurant.Order.Handler.Extensions;
using Restaurant.Receipt.Handler.Extensions;


namespace Restaurant.Orchestrator.Handler.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddOrchestratorHandler(this IServiceCollection services)
        {
            services.AddScoped<ICommandHandler<CreateOrderWithReceiptCommand>, CreateOrderWithReceiptCommandHandler>();
        }
    }
}
