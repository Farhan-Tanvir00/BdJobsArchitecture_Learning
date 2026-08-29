using Restaurant.Order.DTO.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Order.DTO.DTO
{
    public class OrderDto
    {
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public string? ShippingAddress { get; set; }
        public List<LineItemDto> OrderLineItems { get; set; } = new List<LineItemDto>();
        public decimal TotalCost { get; set; }
    }
}
