using Restaurant.Management.DTO.DTO;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.DTO.Queries
{
    public class GetAllRestaurantQuery: IQuery<ApiResponse<List<RestaurantDTO>>>
    {
    }
}
