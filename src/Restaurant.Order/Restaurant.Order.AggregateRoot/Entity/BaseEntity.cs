using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Order.AggregateRoot.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
