using Restaurant.Management.DTO.Entities;

namespace Restaurant.Management.AggregateRoot
{
    public class DishAggregateRoot : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int? KiloCalories { get; set; }

        public RestaurantAggregateRoot? RestaurantDetails { get; set; }
        public int RestaurantDetailsId { get; set; }
    }
}
