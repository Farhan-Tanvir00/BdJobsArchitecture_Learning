using Restaurant.Order.AggregateRoot.Entity;
using Restaurant.Order.DTO.Commands;
using Restaurant.Order.DTO.DTO;

namespace Restaurant.Order.AggregateRoot.Mappings
{
    public static class OrderMapping
    {
        public static OrderAggregateRoot ToEntity(this CreateOrderCommand command)
        {
            var order = new OrderAggregateRoot
            {
                CustomerId = command.RestaurantCustomerId,
                RestaurantId = command.TargetRestaurantId,
                ShippingAddress = command.CustomerShippingAddress,
                OrderLineItems = new List<OrderLineItem>()
            };

            foreach (var lineItem in command.LineItems)
            {
                order.OrderLineItems.Add(lineItem.ToEntity(order.Id));
            }

            return order;
        }

        public static OrderDto? FromEntity(OrderAggregateRoot? order)
        {
            if (order is null)
            {
                return null;
            }

            return new OrderDto
            {   OrderId = order.Id,
                CustomerId = order.CustomerId,
                RestaurantId = order.RestaurantId,
                ShippingAddress = order.ShippingAddress,

                OrderLineItems = order.OrderLineItems?
                    .Select(LineItemMapping.FromEntity)
                    .Where(x => x is not null)
                    .Select(x => x!)
                    .ToList()
                    ?? new List<LineItemDto>(),

                TotalCost = order.OrderLineItems?
                    .Sum(x => x.Quantity * x.UnitPrice)
                    ?? 0
            };
        }
    }
}
