using Restaurant.Management.AggregateRoot.Aggrigates.Interfaces;
using Restaurant.Management.AggregateRoot.Entities;
using Restaurant.Management.AggregateRoot.Mappings;
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
    }
}
