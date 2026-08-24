using Restaurant.Management.AggregateRoot;
using Restaurant.Management.DTO.DTO;
using Restaurant.Management.DTO.Queries;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;


namespace Restaurant.Management.Handler.QueryHandlers
{
    internal class GetOneRestaurantQueryHandler : IQueryHandler<GetOneRestaurantQuery, ApiResponse<RestaurantDTO>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly RestaurantAggregateRoot _restaurantAggrigate;

        public GetOneRestaurantQueryHandler(RestaurantAggregateRoot restaurantAggrigate, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _restaurantAggrigate = restaurantAggrigate;
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
                var restaurantDTO = _restaurantAggrigate.CreateRestaurantDto(restaurant);
                return ApiResponse<RestaurantDTO>.SuccessResponse(restaurantDTO, "Restaurant retrieved successfully", 200);
            }
        }
    }
}
