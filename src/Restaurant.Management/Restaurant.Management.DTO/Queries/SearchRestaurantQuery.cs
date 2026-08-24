using Restaurant.Management.DTO.DTO;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Queries;


namespace Restaurant.Management.DTO.Queries
{
    public class SearchRestaurantQuery : IQuery<ApiResponse<List<RestaurantDTO>>>
    {
        public string? RestaurantName { get; set; }
        public string? Category { get; set; }
        public bool? HasDelivery { get; set; }
    }
}
