using Restaurant.Order.AggregateRoot.Entity;
using Restaurant.Order.DTO.Commands;
using Restaurant.Order.DTO.DTO;

namespace Restaurant.Order.AggregateRoot.Mappings
{
    public static class LineItemMapping
    {
        public static OrderLineItem ToEntity(this CreateOrderLineItemCommand command, int orderId)
        {
            return new OrderLineItem
            {
                OrderId = orderId,
                DishId = command.RestaurantDishId,
                Quantity = command.OrderedQuantity,
                UnitPrice = command.DishUnitPrice,
            };

        }

        public static LineItemDto? FromEntity(OrderLineItem? lineItem)
        {
            if (lineItem is null)
            {
                return null;
            }

            return new LineItemDto
            {
                OrderId = lineItem.OrderId,
                DishId = lineItem.DishId,
                Quantity = lineItem.Quantity,
                UnitPrice = lineItem.UnitPrice,
                LineTotal = lineItem.Quantity * lineItem.UnitPrice
            };
        }
    }
}
