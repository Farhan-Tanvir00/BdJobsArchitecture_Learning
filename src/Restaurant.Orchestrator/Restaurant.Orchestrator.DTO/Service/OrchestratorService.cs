using Restaurant.Orchestrator.DTO.Command;
using Restaurant.Order.DTO.Commands;
using Restaurant.Order.DTO.DTO;
using Restaurant.Order.DTO.Query;
using Restaurant.Receipt.DTO.Command;


namespace Restaurant.Orchestrator.DTO.Service
{
    public static class OrchestratorService
    {
        public static CreateOrderCommand CreateOrderCommand(CreateOrderWithReceiptCommand command)
        {
            return new CreateOrderCommand
            {
                RestaurantCustomerId = command.RestaurantCustomerId,
                TargetRestaurantId = command.TargetRestaurantId,
                CustomerShippingAddress = command.CustomerShippingAddress,

                LineItems = command.LineItems.Select(item => new Order.DTO.Commands.CreateOrderLineItemCommand
                {
                    RestaurantItemId = item.RestaurantItemId,
                    RestaurantDishId = item.RestaurantDishId,
                    OrderedQuantity = item.OrderedQuantity,
                    DishUnitPrice = item.DishUnitPrice
                }).ToList()
            };
        }

        public static GetOrderByIdQuery CreateOrderQuery(int id)
        {
            return new GetOrderByIdQuery { Id = id };
        }

        public static CreateReceiptCommand CreateReceiptCommand(OrderDto orderDto)
        {
            return new CreateReceiptCommand
            {
                RestaurantCustomerId = orderDto.CustomerId,
                TargetRestaurantId = orderDto.RestaurantId,
                CustomerShippingAddress = orderDto.ShippingAddress,
                TotalCost = orderDto.TotalCost,

                LineItems = orderDto.OrderLineItems.Select(item => new CreateReceiptLineItemCommand
                {
                    RestaurantDishId = item.DishId,
                    OrderedQuantity = item.Quantity,
                    DishUnitPrice = item.UnitPrice,
                    LineTotal = item.LineTotal
                }).ToList()
            };
        }


    }
}
