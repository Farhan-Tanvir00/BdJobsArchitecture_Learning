using Restaurant.Management.AggregateRoot.Aggrigates.Interfaces;
using Restaurant.Management.AggregateRoot.Entities;
using Restaurant.Management.AggregateRoot.Mappings;
using Restaurant.Management.AggregateRoot.ValueObjects;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.DTO.DTO;
using Restaurant.Management.DTO.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.AggregateRoot.Aggrigates.Implementations
{
    internal class RestaurantAggrigate : IRestaurentAggrigator
    {
        public RestaurantDetails CreateRestaurant(CreateRestaurantCommand command)
        {
            var restaurant = command.ToEntity();
            restaurant.DishCount = 0;
            restaurant.HasDelivery = false;
            restaurant.IsOpen = false;

            return restaurant;
        }

        public List<RestaurantDTO?> CreateRestaurantDtos(List<RestaurantDetails> restaurantDetails)
        {
            var restaurantDtos = restaurantDetails.Select(r => RestaurantMapper.FromEntitity(r));
            return restaurantDtos.ToList();
        }

        public RestaurantDTO CreateRestaurantDto(RestaurantDetails restaurantDetails)
        {
            var restaurantDto = RestaurantMapper.FromEntitity(restaurantDetails);
            return restaurantDto!;
        }

        public RestaurantDetails UpdateRestaurant(UpdateRestaurantCommand command, RestaurantDetails existingRestaurant)
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

        public RestaurantDetails ActivateDelivery(RestaurantDetails existingRestaurant)
        {
            existingRestaurant.IsOpen = true;
            existingRestaurant.HasDelivery = true;
            return existingRestaurant;
        }


    }
}
