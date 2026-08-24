using Restaurant.Management.Shared.Interfaces.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.DTO.Commands
{
    public class ActiveDeliveryRestaurantCommand : ICommand
    {
        public int RestaurantId { get; set; }
    }
}
