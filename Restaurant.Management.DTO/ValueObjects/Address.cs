using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.DTO.ValueObjects
{
    public class Address
    {
        public string? City { get; set; }
        public string? Street { get; set; }
        public string? PostalCode { get; set; }
    }
}
