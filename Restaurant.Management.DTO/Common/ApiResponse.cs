using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.DTO.Common
{
    public class ApiResponse
    {
        public int Data { get; set; }
        public int ResponseCode { get; set; }
        public string? Message { get; set; }
    }
}
