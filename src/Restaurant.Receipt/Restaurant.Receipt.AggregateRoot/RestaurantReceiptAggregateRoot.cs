using Restaurant.Receipt.AggregateRoot.Entity;
using Restaurant.Receipt.AggregateRoot.Mappings;
using Restaurant.Receipt.DTO.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Receipt.AggregateRoot
{
    public class RestaurantReceiptAggregateRoot : BaseEntity
    {
        public int CustomerId { get; set; }
        public int RestaurantId { get; set; }
        public string? ShippingAddress { get; set; }
        public List<ReceiptLineItem> OrderLineItems { get; set; } = new List<ReceiptLineItem>();
        public decimal TotalCost { get; set; }


        public RestaurantReceiptAggregateRoot CreateReceipt(CreateReceiptCommand command)
        {
            return command.ToEntity();
        }

        //public OrderDto GetOrderDto(OrderAggregateRoot orderAggregateRoot)
        //{
        //    var dto = OrderMapping.FromEntity(orderAggregateRoot);
        //    return dto!;
        //}
    }
}
