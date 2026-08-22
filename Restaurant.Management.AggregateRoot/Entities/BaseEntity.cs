using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.AggregateRoot.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string? CreatedAt { get; set; }
        public string? CreatedBy { get; set; }
    }
}
