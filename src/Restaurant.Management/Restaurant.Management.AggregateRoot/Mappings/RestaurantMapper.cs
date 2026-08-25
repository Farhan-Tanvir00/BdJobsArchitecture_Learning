using Restaurant.Management.DTO.Commands;
using Restaurant.Management.DTO.DTO;
using Restaurant.Management.DTO.ValueObjects;

namespace Restaurant.Management.AggregateRoot.Mappings
{
    public static class RestaurantMapper
    {
        public static RestaurantAggregateRoot ToEntity(this CreateRestaurantCommand restaurant)
        {
            return new RestaurantAggregateRoot
            {
                Name = restaurant.RestaurantName,
                Description = restaurant.RestaurantDescription,
                Category = restaurant.RestaurantCategory,
                ContactEmail = restaurant.RestaurantContactEmail,
                ContactNumber = restaurant.RestaurantContactNumber,
                Address = new Address
                {
                    City = restaurant.RestaurantCity,
                    Street = restaurant.RestaurantStreet,
                    PostalCode = restaurant.RestaurantPostalCode
                }
            };
        }

        public static RestaurantDTO? FromEntitity(RestaurantAggregateRoot? restaurantDetails)
        {
            if (restaurantDetails is null)
            {
                return null;
            }

            return new RestaurantDTO()
            {
                RestaurantName = restaurantDetails.Name,
                RestaurantDescription = restaurantDetails.Description,
                RestaurantCategory = restaurantDetails.Category,

                RestaurantContactEmail = restaurantDetails.ContactEmail,
                RestaurantContactNumber = restaurantDetails.ContactNumber,

                RestaurantCity = restaurantDetails.Address?.City,
                RestaurantStreet = restaurantDetails.Address?.Street,
                RestaurantPostalCode = restaurantDetails.Address?.PostalCode,

                RestaurantHasDelivery = restaurantDetails.HasDelivery,
                RestaurantIsOpen = restaurantDetails.IsOpen,
                RestaurantDishCount = restaurantDetails.DishCount
            };
        }
    }
}
