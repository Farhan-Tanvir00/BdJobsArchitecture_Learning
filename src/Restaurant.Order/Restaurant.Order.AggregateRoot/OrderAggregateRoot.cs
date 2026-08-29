using Restaurant.Order.AggregateRoot.Entity;
using Restaurant.Order.AggregateRoot.Mappings;
using Restaurant.Order.DTO.Commands;

namespace Restaurant.Order.AggregateRoot
{
    public class OrderAggregateRoot: BaseEntity
    {
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public string? ShippingAddress { get; set; }
        public List<OrderLineItem> OrderLineItems { get; set; } = new List<OrderLineItem>();
        public decimal TotalCost => OrderLineItems.Sum(x => x.LineTotal);


        public OrderAggregateRoot CreateOrder(CreateOrderCommand command)
        {
            return command.ToEntity();
        }
    }
}
