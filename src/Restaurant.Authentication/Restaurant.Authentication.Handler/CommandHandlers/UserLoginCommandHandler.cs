using FluentValidation;
using Restaurant.Authentication.AggregateRoot;
using Restaurant.Authentication.DTO.Commands;
using Restaurant.Authentication.Handler.Services;
using Restaurant.Authentication.Repository.Implementations;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Shared.Exceptions;


namespace Restaurant.Authentication.Handler.CommandHandlers
{
    public class UserLoginCommandHandler : ICommandHandler<UserLoginCommand>
    {
        private readonly UserRepository _userRepository;
        private readonly UserAggregateRoot _userAggregateRoot;
        private readonly ITokenService _tokenService;
        private readonly IValidator<UserLoginCommand> _validator;


        public UserLoginCommandHandler(UserRepository userRepository, ITokenService tokenService, 
            UserAggregateRoot userAggregateRoot, IValidator<UserLoginCommand> validator)
        {
            _userRepository = userRepository;
            _userAggregateRoot = userAggregateRoot;
            _tokenService = tokenService;
            _validator = validator;
        }
        public async Task<ApiResponse<object?>> HandleAsync(UserLoginCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                var validationErrors = validationResult.ToDictionary();
                return ApiResponse<object?>.FailedResponse(validationErrors, "Validation failed", 400);
            }

            var user = await _userRepository.GetByUserNameAsync(command.AppUserName!);
            if (user is null)
            {
                return ApiResponse<object?>.FailedResponse("Invalid credentials", 400);
            }

            var correctCredential = _userAggregateRoot.checkUserCredentials(user, command);

            if (!correctCredential)
            {
                return ApiResponse<object?>.FailedResponse("Invalid credentials", 400);
            }

            var token = _tokenService.GenerateToken(user);
            return ApiResponse<object?>.SuccessResponse(token, "Restaurant created successfully", 201);
        }
    }
}
