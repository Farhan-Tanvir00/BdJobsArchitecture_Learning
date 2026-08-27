
using Restaurant.Authentication.AggregateRoot;
using Restaurant.Authentication.DTO.Commands;
using Restaurant.Authentication.Repository.Implementations;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;

namespace Restaurant.Authentication.Handler.CommandHandlers
{
    public class UserRegisterCommandHandler : ICommandHandler<UserRegisterCommand>
    {
        private readonly UserRepository _userRepository;
        private readonly RoleRepository _roleRepository;
        private readonly UserAggregateRoot _userAggregateRoot;

        public UserRegisterCommandHandler(UserRepository userRepository, RoleRepository roleRepository, UserAggregateRoot userAggregateRoot)
        {
            _userRepository = userRepository;
            _roleRepository = roleRepository;
            _userAggregateRoot = userAggregateRoot;
        }

        public async Task<ApiResponse<object?>> HandleAsync(UserRegisterCommand command)
        {
            var existingUser = await _userRepository.GetByUserNameAsync(command.AppUserName);

            if (existingUser != null)
            {
                return ApiResponse<object?>.FailedResponse("Username already taken.", 400);
            }

            var newUser = _userAggregateRoot.CreateNewUser(command);
            var initialRole = await _roleRepository.GetDefaultRoleAsync();
            _userAggregateRoot.AddInitialRole(newUser, initialRole);

            _userRepository.Add(newUser);

            await _userRepository.SaveChangesAsync();

            return ApiResponse<object?>.SuccessResponse(new { UserId = newUser.Id }, "User registered successfully.", 201);
        }
    }
}
