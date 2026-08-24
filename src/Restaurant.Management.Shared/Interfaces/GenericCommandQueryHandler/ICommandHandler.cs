using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task<ApiResponse<object?>> HandleAsync(TCommand command);
    }
}
