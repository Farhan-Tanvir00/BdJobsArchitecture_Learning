using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Receipt.AggregateRoot.Extensions;
using Restaurant.Receipt.DTO.Command;
using Restaurant.Receipt.Handler.CommandHandlers;
using Restaurant.Receipt.Repository.Extensions;
using Restaurant.Shared.Interfaces.ServiceBus;



namespace Restaurant.Receipt.Handler.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurrantReceiptHandler(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<ICommandHandler<CreateReceiptCommand>, CreateReceiptCommandHandler>();

            service.AddAddRestaurrantReceiptAggregateRoot();
            service.AddRestaurrantReceiptRepository(configuration);

        }
    }
}
