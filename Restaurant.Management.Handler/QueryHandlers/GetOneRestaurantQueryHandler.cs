using Restaurant.Management.DTO.DTO;
using Restaurant.Management.DTO.Queries;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.Handler.QueryHandlers
{
    internal class GetOneRestaurantQueryHandler : IQueryHandler<GetOneRestaurantQuery, ApiResponse<RestaurantDTO>>
    {
        public Task<ApiResponse<RestaurantDTO>> HandleAsync(GetOneRestaurantQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
