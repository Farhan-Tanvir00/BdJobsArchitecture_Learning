using Restaurant.Receipt.AggregateRoot.Entity;
using Restaurant.Receipt.DTO.Command;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Receipt.AggregateRoot.Mappings
{
    public static class LineItemMapping
    {
        public static ReceiptLineItem ToEntity(this CreateReceiptLineItemCommand command, int receiptId)
        {
            return new ReceiptLineItem
            {
                ReceiptId = receiptId,
                DishId = command.RestaurantDishId,
                Quantity = command.OrderedQuantity,
                UnitPrice = command.DishUnitPrice,
            };

        }
    }
}
