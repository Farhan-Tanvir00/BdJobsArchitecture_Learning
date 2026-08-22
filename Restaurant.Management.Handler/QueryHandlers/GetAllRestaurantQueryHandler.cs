using Microsoft.EntityFrameworkCore;
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
    internal class GetAllRestaurantQueryHandler : IQueryHandler<GetAllRestaurantQuery, ApiResponse<List<RestaurantDTO>>>
    {
        private readonly IRestaurentAggrigator _restaurantAggrigator;
        private readonly IUnitOfWork _unitOfWork;

        public GetAllRestaurantQueryHandler(IRestaurentAggrigator restaurantAggrigator, IUnitOfWork unitOfWork)
        {
            _restaurantAggrigator = restaurantAggrigator;
            _unitOfWork = unitOfWork;
        }

        public async Task<ApiResponse<List<RestaurantDTO>>> HandleAsync(GetAllRestaurantQuery query)
        {
            var restaurants = await _unitOfWork.RestaurantRepository.GetAll().ToListAsync();

            var restaurantDTOs = _restaurantAggrigator.CreateRestaurantDtos(restaurants);

            return ApiResponse<List<RestaurantDTO>>.SuccessResponse(restaurantDTOs!, "Restaurants retrieved successfully", 200);
        }
    }
}
