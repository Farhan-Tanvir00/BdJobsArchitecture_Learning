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
    internal class SearchRestaurantQueryHandler : IQueryHandler<SearchRestaurantQuery, ApiResponse<List<RestaurantDTO>>>
    {
        private readonly IRestaurentAggrigator _restaurantAggrigator;
        private readonly IUnitOfWork _unitOfWork;

        public SearchRestaurantQueryHandler(IRestaurentAggrigator restaurantAggrigator, IUnitOfWork unitOfWork)
        {
            _restaurantAggrigator = restaurantAggrigator;
            _unitOfWork = unitOfWork;
        }
        public Task<ApiResponse<List<RestaurantDTO>>> HandleAsync(SearchRestaurantQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
