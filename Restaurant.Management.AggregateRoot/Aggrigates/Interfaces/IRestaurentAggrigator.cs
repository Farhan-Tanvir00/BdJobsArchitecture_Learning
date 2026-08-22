using Restaurant.Management.AggregateRoot.Entities;
using Restaurant.Management.DTO.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.AggregateRoot.Aggrigates.Interfaces
{
    public interface IRestaurentAggrigator
    {
        RestaurantDetails CreateRestaurant(CreateRestaurantCommand command);
    }
}
