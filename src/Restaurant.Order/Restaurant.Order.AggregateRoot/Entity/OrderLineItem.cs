using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Order.AggregateRoot.Entity
{
    public class OrderLineItem : BaseEntity
    {
        public int OrderId { get; set; }
        public int DishId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal => Quantity * UnitPrice;
    }
}
