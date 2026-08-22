using Restaurant.Management.AggregateRoot.ValueObjects;

namespace Restaurant.Management.AggregateRoot.Entities
{
    public class RestaurantDetails: BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public required string Category { get; set; }
        public int DishCount { get; set; }
        public bool HasDelivery { get; set; }
        public bool IsOpen { get; set; }

        public string? ContactEmail { get; set; }
        public string? ContactNumber { get; set; }

        public Address? Address { get; set; }
        public List<Dish> Dishes { get; set; } = new List<Dish>();
    }
}
