using FluentValidation;
using Restaurant.Management.AggregateRoot;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Shared.Exceptions;
using System.ComponentModel.DataAnnotations;


namespace Restaurant.Management.Handler.CommandHandlers
{
    internal class CreateRestaurantCommandHandler : ICommandHandler<CreateRestaurantCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RestaurantAggregateRoot _restaurantAggrigate;
        private readonly IValidator<CreateRestaurantCommand> _createRestaurantValidator;

        public CreateRestaurantCommandHandler(RestaurantAggregateRoot restaurantAggrigate, IUnitOfWork unitOfWork,
            IValidator<CreateRestaurantCommand> createRestaurantValidator)
        {
            _unitOfWork = unitOfWork;
            _restaurantAggrigate = restaurantAggrigate;
            _createRestaurantValidator = createRestaurantValidator;
        }
        public async Task<ApiResponse<object?>> HandleAsync(CreateRestaurantCommand command)
        {
            var validationResult = await _createRestaurantValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                var validationErrors = validationResult.ToDictionary();
                return ApiResponse<object?>.FailedResponse(validationErrors, "Validation failed", 400);
            }

            var restaurant = _restaurantAggrigate.CreateRestaurant(command);

            _unitOfWork.RestaurantRepository.Add(restaurant);
            bool result = await _unitOfWork.SaveChangesAsync();

            if (!result)
            {
                return ApiResponse<object?>.FailedResponse("Failed to create restaurant", 500);
            }

            return ApiResponse<object?>.SuccessResponse("Restaurant created successfully", 201);
        }
    }
}
