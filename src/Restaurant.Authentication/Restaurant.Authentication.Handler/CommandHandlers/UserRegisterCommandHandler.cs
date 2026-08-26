
using Restaurant.Authentication.DTO.Commands;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;

namespace Restaurant.Authentication.Handler.CommandHandlers
{
    public class UserRegisterCommandHandler : ICommandHandler<UserRegisterCommand>
    {
        public Task<ApiResponse<object?>> HandleAsync(UserRegisterCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
