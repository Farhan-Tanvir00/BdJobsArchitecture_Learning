using Restaurant.Management.AggregateRoot.Aggrigates.Interfaces;
using Restaurant.Management.DTO.DTO;
using Restaurant.Management.DTO.Queries;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.Handler.QueryHandlers
{
    internal class GetOneRestaurantQueryHandler : IQueryHandler<GetOneRestaurantQuery, ApiResponse<RestaurantDTO>>
    {
        private readonly IRestaurentAggrigator _restaurantAggrigator;
        private readonly IUnitOfWork _unitOfWork;

        public GetOneRestaurantQueryHandler(IRestaurentAggrigator restaurantAggrigator, IUnitOfWork unitOfWork)
        {
            _restaurantAggrigator = restaurantAggrigator;
            _unitOfWork = unitOfWork;
        }
        public async Task<ApiResponse<RestaurantDTO>> HandleAsync(GetOneRestaurantQuery query)
        {
            var restaurant = await _unitOfWork.RestaurantRepository.GetByIdAsync(query.RestaurantId);
            if (restaurant == null)
            {
                return ApiResponse<RestaurantDTO>.FailedResponse("Restaurant not found", 404);

            }
            else
            {
                var restaurantDTO = _restaurantAggrigator.CreateRestaurantDto(restaurant);
                return ApiResponse<RestaurantDTO>.SuccessResponse(restaurantDTO, "Restaurant retrieved successfully", 200);
            }
        }
    }
}
