using Restaurant.Orchestrator.DTO.Command;
using Restaurant.Order.DTO.Commands;
using Restaurant.Order.DTO.DTO;
using Restaurant.Order.DTO.Query;
using Restaurant.Receipt.DTO.Command;


namespace Restaurant.Orchestrator.DTO.Service
{
    public static class OrchestratorService
    {
        public static CreateOrderCommand CreateOrderCommand(CreateOrderWiseReceiptCommand command)
        {
            return new CreateOrderCommand
            {
                RestaurantCustomerId = command.RestaurantCustomerId,
                TargetRestaurantId = command.TargetRestaurantId,
                CustomerShippingAddress = command.CustomerShippingAddress,

                LineItems = command.LineItems.Select(item => new CreateOrderLineItemCommand
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
            throw new NotImplementedException();
        }

        public static CreateReceiptCommand CreateReceiptCommand(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }

    }
}
