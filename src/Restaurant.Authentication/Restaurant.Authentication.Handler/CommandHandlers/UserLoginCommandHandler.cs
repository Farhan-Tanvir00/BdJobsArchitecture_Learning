using Restaurant.Authentication.AggregateRoot;
using Restaurant.Authentication.DTO.Commands;
using Restaurant.Authentication.Repository.Implementations;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;


namespace Restaurant.Authentication.Handler.CommandHandlers
{
    public class UserLoginCommandHandler : ICommandHandler<UserLoginCommand>
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;
        private readonly UserAggregateRoot _userAggregateRoot;

        public UserLoginCommandHandler(UserRepository userRepository, RoleRepository roleRepository, UserAggregateRoot userAggregateRoot)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userAggregateRoot = userAggregateRoot;
        }
        public async Task<ApiResponse<object?>> HandleAsync(UserLoginCommand command)
        {
            var user = await _userRepository.GetByUserNameAsync(command.AppUserName!);
            if (user is null)
            {
                
            }

            throw new NotImplementedException();
        }
    }
}
