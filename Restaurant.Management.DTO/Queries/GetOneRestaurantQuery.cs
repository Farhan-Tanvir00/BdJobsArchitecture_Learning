using Restaurant.Management.DTO.DTO;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Queries;

namespace Restaurant.Management.DTO.Queries
{
    public class GetOneRestaurantQuery : IQuery<ApiResponse<RestaurantDTO>>
    {
        public int RestaurantId { get; set; }
    }
}
