using Restaurant.Management.AggregateRoot.Entities;
using Restaurant.Management.DTO.Commands;

namespace Restaurant.Management.AggregateRoot.Mappings
{
    public static class RestaurantMapper
    {
        public static RestaurantDetails ToEntity(this CreateRestaurantCommand  restaurant)
        {
            return new RestaurantDetails
            {
                Name = restaurant.RestaurantName,
                Description = restaurant.RestaurantDescription,
                Category = restaurant.RestaurantCategory,
                ContactEmail = restaurant.RestaurantContactEmail,
                ContactNumber = restaurant.RestaurantContactNumber,
                Address = new ValueObjects.Address
                {
                    City = restaurant.RestaurantCity,
                    Street = restaurant.RestaurantStreet,
                    PostalCode = restaurant.RestaurantPostalCode
                }
            };
        }
    }
}
