using Restaurant.Management.DTO.DTO;
using Restaurant.Management.DTO.Queries;
using Restaurant.Management.Repository.Interfaces;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;

namespace Restaurant.Management.Handler.QueryHandlers
{
    internal class SearchRestaurantQueryHandler : IQueryHandler<SearchRestaurantQuery, ApiResponse<List<RestaurantDTO>>>
    {
        private readonly IUnitOfWork _unitOfWork;

        public SearchRestaurantQueryHandler(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public Task<ApiResponse<List<RestaurantDTO>>> HandleAsync(SearchRestaurantQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
