using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Receipt.AggregateRoot.Entity
{
    public class ReceiptLineItem : BaseEntity
    {
        public int ReceiptId { get; set; }
        public int DishId { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal LineTotal { get; set; }
    }
}
