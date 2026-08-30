using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Receipt.AggregateRoot.Extensions;
using Restaurant.Receipt.DTO.Command;
using Restaurant.Receipt.Handler.CommandHandlers;
using Restaurant.Receipt.Repository.Extensions;
using Restaurant.Shared.Interfaces.ServiceBus;
using Restaurant.Shared.ServiceBus;


namespace Restaurant.Receipt.Handler.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static void AddRestaurrantReceiptHandler(this IServiceCollection service, IConfiguration configuration)
        {
            service.AddScoped<ICommandHandler<CreateReceiptCommand>, CreateReceiptCommandHandler>();

            service.AddAddRestaurrantReceiptAggregateRoot();
            service.AddRestaurrantReceiptRepository(configuration);


            //For Making The Command and Query Generation Generic
            service.AddScoped<IRequestDispatcher, RequestDispatcher>();
        }
    }
}
