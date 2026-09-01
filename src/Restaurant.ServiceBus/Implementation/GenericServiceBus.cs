using Microsoft.Extensions.DependencyInjection;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Command;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Management.Shared.Interfaces.Queries;

namespace Restaurant.ServiceBus.Implementation
{
    public class GenericServiceBus
    {
        private readonly IServiceProvider _serviceProvider;

        public GenericServiceBus(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<ApiResponse<object?>> SendCommandAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            return handler.HandleAsync(command);
        }

        public Task<TResult> SendQueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return handler.HandleAsync(query);
        }
    }
}
