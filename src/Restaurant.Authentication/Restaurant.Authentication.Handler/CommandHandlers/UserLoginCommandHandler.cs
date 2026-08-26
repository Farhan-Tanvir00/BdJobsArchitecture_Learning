using Restaurant.Authentication.DTO.Commands;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;


namespace Restaurant.Authentication.Handler.CommandHandlers
{
    public class UserLoginCommandHandler : ICommandHandler<UserLoginCommand>
    {
        public Task<ApiResponse<object?>> HandleAsync(UserLoginCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
