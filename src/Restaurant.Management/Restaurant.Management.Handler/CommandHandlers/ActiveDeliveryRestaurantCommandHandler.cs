using FluentValidation;
using Restaurant.Management.AggregateRoot;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Shared.Exceptions;


namespace Restaurant.Management.Handler.CommandHandlers
{
    internal class ActiveDeliveryRestaurantCommandHandler : ICommandHandler<ActiveDeliveryRestaurantCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RestaurantAggregateRoot _restaurantAggrigator;
        private readonly IValidator<ActiveDeliveryRestaurantCommand> _activeRestaurantCommandValidator;
        public ActiveDeliveryRestaurantCommandHandler(RestaurantAggregateRoot restaurantAggrigator, IUnitOfWork unitOfWork,
            IValidator<ActiveDeliveryRestaurantCommand> activeRestaurantCommandValidator)
        {
            _unitOfWork = unitOfWork;
            _restaurantAggrigator = restaurantAggrigator;
            _activeRestaurantCommandValidator = activeRestaurantCommandValidator;
        }

        public async Task<ApiResponse<object?>> HandleAsync(ActiveDeliveryRestaurantCommand command)
        {

            var validationResult = await _activeRestaurantCommandValidator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                var validationErrors = validationResult.ToDictionary();
                return ApiResponse<object?>.FailedResponse(validationErrors, "Validation failed", 400);
            }

            var rstaurant = await _unitOfWork.RestaurantRepository.GetByIdAsync(command.RestaurantId);
            if (rstaurant == null)
            {
                return ApiResponse<object?>.FailedResponse("Could not find restaurant", 404);
            }

            var activeDeliveryResult = _restaurantAggrigator.ActivateDelivery(rstaurant);

            _unitOfWork.RestaurantRepository.Update(activeDeliveryResult);
            var result = await _unitOfWork.SaveChangesAsync();

            if (!result)
            {
                return ApiResponse<object?>.FailedResponse("Failed to Activate Delivery", 500);
            }

            return ApiResponse<object?>.SuccessResponse("Delivery activated successfully");
        }
    }
}
