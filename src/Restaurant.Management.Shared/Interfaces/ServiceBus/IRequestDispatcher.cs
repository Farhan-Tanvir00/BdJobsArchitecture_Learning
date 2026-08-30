using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Command;
using Restaurant.Management.Shared.Interfaces.Queries;

namespace Restaurant.Shared.Interfaces.ServiceBus
{
    public interface IRequestDispatcher
    {
        public Task<TResult> QueryAsync<TQuery, TResult>(TQuery query) where TQuery : IQuery<TResult>;
        public Task<ApiResponse<object?>> CommandAsync<TCommand>(TCommand command) where TCommand : ICommand;
    }
}
