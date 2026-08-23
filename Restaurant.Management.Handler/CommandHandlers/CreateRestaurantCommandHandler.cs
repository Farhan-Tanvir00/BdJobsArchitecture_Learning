using Restaurant.Management.AggregateRoot.Aggrigates;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Commands;


namespace Restaurant.Management.Handler.CommandHandlers
{
    internal class CreateRestaurantCommandHandler : ICommandHandler<CreateRestaurantCommand>
    {
        private readonly IUnitOfWork _unitOfWork;
        public CreateRestaurantCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<object?>> HandleAsync(CreateRestaurantCommand command)
        {
            var restaurant = RestaurantAggrigate.CreateRestaurant(command);

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
