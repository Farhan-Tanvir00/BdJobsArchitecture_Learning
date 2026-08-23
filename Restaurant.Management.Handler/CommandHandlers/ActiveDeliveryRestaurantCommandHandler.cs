using Restaurant.Management.AggregateRoot.Aggrigates.Interfaces;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Commands;


namespace Restaurant.Management.Handler.CommandHandlers
{
    internal class ActiveDeliveryRestaurantCommandHandler : ICommandHandler<ActiveDeliveryRestaurantCommand>
    {
        private readonly IRestaurentAggrigator _restaurantAggrigator;
        private readonly IUnitOfWork _unitOfWork;
        public ActiveDeliveryRestaurantCommandHandler(IRestaurentAggrigator restaurantAggrigator, IUnitOfWork unitOfWork)
        {
            _restaurantAggrigator = restaurantAggrigator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<object?>> HandleAsync(ActiveDeliveryRestaurantCommand command)
        {
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
