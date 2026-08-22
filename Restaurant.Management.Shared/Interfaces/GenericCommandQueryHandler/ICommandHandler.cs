using Restaurant.Management.Shared.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.Shared.Interfaces.Commands
{
    public interface ICommandHandler<TCommand> where TCommand : ICommand
    {
        Task HandleAsync(TCommand command);
    }
}
