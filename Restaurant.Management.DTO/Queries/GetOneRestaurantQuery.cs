using Restaurant.Management.Shared.Interfaces.Queries;

namespace Restaurant.Management.DTO.Queries
{
    public class GetOneRestaurantQuery : IQuery<GetOneRestaurantQuery>
    {
        public int RestaurantId { get; set; }
    }
}
