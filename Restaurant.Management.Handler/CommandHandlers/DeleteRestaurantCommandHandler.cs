using Restaurant.Management.DTO.Commands;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.Handler.CommandHandlers
{
    internal class DeleteRestaurantCommandHandler : ICommandHandler<DeleteRestaurantCommand>
    {
        public Task<ApiResponse<object?>> HandleAsync(DeleteRestaurantCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
