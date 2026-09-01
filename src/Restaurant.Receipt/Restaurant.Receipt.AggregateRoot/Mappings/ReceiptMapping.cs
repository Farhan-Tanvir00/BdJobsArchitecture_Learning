using Restaurant.Receipt.AggregateRoot.Entity;
using Restaurant.Receipt.DTO.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Receipt.AggregateRoot.Mappings
{
    public static class ReceiptMapping
    {
        public static RestaurantReceiptAggregateRoot ToEntity(this CreateReceiptCommand command)
        {
            var order = new RestaurantReceiptAggregateRoot
            {
                CustomerId = command.RestaurantCustomerId,
                RestaurantId = command.TargetRestaurantId,
                ShippingAddress = command.CustomerShippingAddress,
                TotalCost = command.TotalCost,
                OrderLineItems = new List<ReceiptLineItem>()
            };

            foreach (var lineItem in command.LineItems)
            {
                order.OrderLineItems.Add(lineItem.ToEntity(order.Id));
            }

            return order;
        }
    }
}
