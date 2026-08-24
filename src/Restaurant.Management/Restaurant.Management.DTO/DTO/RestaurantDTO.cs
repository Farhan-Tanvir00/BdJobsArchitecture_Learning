using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.DTO.DTO
{
    public class RestaurantDTO
    {
        public  string? RestaurantName { get; set; }
        public  string? RestaurantDescription { get; set; }
        public  string? RestaurantCategory { get; set; }

        public string? RestaurantContactEmail { get; set; }
        public string? RestaurantContactNumber { get; set; }

        public string? RestaurantCity { get; set; }
        public string? RestaurantStreet { get; set; }
        public string? RestaurantPostalCode { get; set; }

        public bool RestaurantHasDelivery { get; set; }
        public bool RestaurantIsOpen { get; set; }
        public int RestaurantDishCount { get; set; }

    }
}
