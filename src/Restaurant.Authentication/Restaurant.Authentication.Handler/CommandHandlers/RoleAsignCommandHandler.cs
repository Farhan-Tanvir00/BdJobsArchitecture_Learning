using Restaurant.Authentication.DTO.Commands;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;


namespace Restaurant.Authentication.Handler.CommandHandlers
{
    public class RoleAsignCommandHandler : ICommandHandler<RoleAsignCommand>
    {
        public Task<ApiResponse<object?>> HandleAsync(RoleAsignCommand command)
        {
            throw new NotImplementedException();
        }
    }
}
