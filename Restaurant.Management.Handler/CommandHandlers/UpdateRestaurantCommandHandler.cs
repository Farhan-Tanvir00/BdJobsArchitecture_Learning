using Restaurant.Management.AggregateRoot.Aggrigates;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Commands;


namespace Restaurant.Management.Handler.CommandHandlers
{
    internal class UpdateRestaurantCommandHandler : ICommandHandler<UpdateRestaurantCommand>
    {
        private readonly IUnitOfWork _unitOfWork;

        public UpdateRestaurantCommandHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<object?>> HandleAsync(UpdateRestaurantCommand command)
        {
            var rstaurant = await _unitOfWork.RestaurantRepository.GetByIdAsync(command.RestaurantId);
            if (rstaurant == null)
            {
                return ApiResponse<object?>.FailedResponse("Could not find restaurant", 404);
            }

            var updatedRestaurant = RestaurantAggrigate.UpdateRestaurant(command, rstaurant);

            _unitOfWork.RestaurantRepository.Update(updatedRestaurant);
            var result = await _unitOfWork.SaveChangesAsync();

            if(!result)
            {
                return ApiResponse<object?>.FailedResponse("Failed to update restaurant", 500);
            }

            return ApiResponse<object?>.SuccessResponse("Updated restaurant successfully");
        }
    }
}
