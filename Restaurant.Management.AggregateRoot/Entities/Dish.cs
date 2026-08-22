using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.AggregateRoot.Entities
{
    public class Dish : BaseEntity
    {
        public required string Name { get; set; }
        public required string Description { get; set; }
        public decimal Price { get; set; }
        public int? KiloCalories { get; set; }

        public RestaurantDetails? RestaurantDetails { get; set; }
        public int RestaurantDetailsId { get; set; }
    }
}
