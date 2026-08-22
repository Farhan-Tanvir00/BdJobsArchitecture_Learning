using Restaurant.Management.AggregateRoot.Entities;
using Restaurant.Management.DTO.Commands;
using Restaurant.Management.DTO.DTO;
using Restaurant.Management.DTO.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.AggregateRoot.Aggrigates.Interfaces
{
    public interface IRestaurentAggrigator
    {
        RestaurantDetails CreateRestaurant(CreateRestaurantCommand command);
        List<RestaurantDTO?> CreateRestaurantDtos(List<RestaurantDetails> restaurantDetails);
    }
}
