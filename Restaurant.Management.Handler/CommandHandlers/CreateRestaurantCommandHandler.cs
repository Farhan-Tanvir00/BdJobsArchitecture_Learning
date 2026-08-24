using Restaurant.Management.AggregateRoot;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Commands;


namespace Restaurant.Management.Handler.CommandHandlers
{
    internal class CreateRestaurantCommandHandler : ICommandHandler<CreateRestaurantCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RestaurantAggregateRoot _restaurantAggrigate;

        public CreateRestaurantCommandHandler(RestaurantAggregateRoot restaurantAggrigate, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _restaurantAggrigate = restaurantAggrigate;
        }
        public async Task<ApiResponse<object?>> HandleAsync(CreateRestaurantCommand command)
        {
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
