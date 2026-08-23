using Restaurant.Management.AggregateRoot.Aggrigates.Interfaces;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.Handler.CommandHandlers
{
    internal class DeleteRestaurantCommandHandler : ICommandHandler<DeleteRestaurantCommand>
    {
        private readonly IRestaurentAggrigator _restaurantAggrigator;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteRestaurantCommandHandler(IRestaurentAggrigator restaurantAggrigator, IUnitOfWork unitOfWork)
        {
            _restaurantAggrigator = restaurantAggrigator;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<object?>> HandleAsync(DeleteRestaurantCommand command)
        {
            var rstaurant = await _unitOfWork.RestaurantRepository.GetByIdAsync(command.RestaurantId);
            if (rstaurant == null)
            {
                return ApiResponse<object?>.FailedResponse("Could not find restaurant", 404);
            }

            _unitOfWork.RestaurantRepository.Remove(rstaurant);
            var result = await _unitOfWork.SaveChangesAsync();

            if (!result)
            {
                return ApiResponse<object?>.FailedResponse("Could not delete restaurant", 500);

            }
            return ApiResponse<object?>.SuccessResponse("Restaurant deleted successfully", 200);

        } 
    }
}
