using Microsoft.EntityFrameworkCore;
using Restaurant.Management.AggregateRoot;
using Restaurant.Management.DTO.DTO;
using Restaurant.Management.DTO.Queries;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;

namespace Restaurant.Management.Handler.QueryHandlers
{
    internal class GetAllRestaurantQueryHandler : IQueryHandler<GetAllRestaurantQuery, ApiResponse<List<RestaurantDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RestaurantAggregateRoot _restaurantAggrigate;

        public GetAllRestaurantQueryHandler(RestaurantAggregateRoot restaurantAggrigate, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _restaurantAggrigate = restaurantAggrigate;
        }

        public async Task<ApiResponse<List<RestaurantDTO>>> HandleAsync(GetAllRestaurantQuery query)
        {

            var restaurants = await _unitOfWork.RestaurantRepository.GetAll().ToListAsync();

            var restaurantDTOs = _restaurantAggrigate.CreateRestaurantDtos(restaurants);

            return ApiResponse<List<RestaurantDTO>>.SuccessResponse(restaurantDTOs!, "Restaurants retrieved successfully", 200);
        }
    }
}
