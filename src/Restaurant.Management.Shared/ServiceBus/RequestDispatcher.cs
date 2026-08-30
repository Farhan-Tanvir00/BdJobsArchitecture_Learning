using Microsoft.Extensions.DependencyInjection;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Command;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Management.Shared.Interfaces.Queries;
using Restaurant.Shared.Interfaces.ServiceBus;

namespace Restaurant.Shared.ServiceBus
{
    public class RequestDispatcher : IRequestDispatcher
    {
        private readonly IServiceProvider _serviceProvider;
        public RequestDispatcher(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        public Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>
        {
            var handler = _serviceProvider.GetRequiredService<IQueryHandler<TQuery, TResult>>();
            return handler.HandleAsync(query);
        }

        public Task<ApiResponse<object?>> CommandAsync<TCommand>(TCommand command) where TCommand : ICommand
        {
            var handler = _serviceProvider.GetRequiredService<ICommandHandler<TCommand>>();
            return handler.HandleAsync(command);
        }
    }
}


//For Making The Command and Query Generation Generic....