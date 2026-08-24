using Restaurant.Management.AggregateRoot.Mappings;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.DTO.DTO;
using Restaurant.Management.DTO.Entities;
using Restaurant.Management.DTO.ValueObjects;

namespace Restaurant.Management.AggregateRoot
{
    public class RestaurantAggregateRoot : BaseEntity
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
        public List<DishAggregateRoot> Dishes { get; set; } = new List<DishAggregateRoot>();

        public RestaurantAggregateRoot CreateRestaurant(CreateRestaurantCommand command)
        {
            var restaurant = command.ToEntity();
            restaurant.DishCount = 0;
            restaurant.HasDelivery = false;
            restaurant.IsOpen = false;

            return restaurant;
        }

        public List<RestaurantDTO?> CreateRestaurantDtos(List<RestaurantAggregateRoot> restaurantDetails)
        {
            var restaurantDtos = restaurantDetails.Select(r => RestaurantMapper.FromEntitity(r));
            return restaurantDtos.ToList();
        }

        public RestaurantDTO CreateRestaurantDto(RestaurantAggregateRoot restaurantDetails)
        {
            var restaurantDto = RestaurantMapper.FromEntitity(restaurantDetails);
            return restaurantDto!;
        }

        public RestaurantAggregateRoot UpdateRestaurant(UpdateRestaurantCommand command, RestaurantAggregateRoot existingRestaurant)
        {
            existingRestaurant.Name = command.RestaurantName;
            existingRestaurant.Description = command.RestaurantDescription;
            existingRestaurant.Category = command.RestaurantCategory;
            existingRestaurant.ContactEmail = command.RestaurantContactEmail;
            existingRestaurant.ContactNumber = command.RestaurantContactNumber;

            existingRestaurant.Address?.City = command.RestaurantCity;
            existingRestaurant.Address?.Street = command.RestaurantStreet;
            existingRestaurant.Address?.PostalCode = command.RestaurantPostalCode;

            return existingRestaurant;
        }

        public RestaurantAggregateRoot ActivateDelivery(RestaurantAggregateRoot existingRestaurant)
        {
            existingRestaurant.IsOpen = true;
            existingRestaurant.HasDelivery = true;
            return existingRestaurant;
        }
    }
}
