using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Authentication.DTO.Entity
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public string? CreatedAt { get; set; }
    }
}
