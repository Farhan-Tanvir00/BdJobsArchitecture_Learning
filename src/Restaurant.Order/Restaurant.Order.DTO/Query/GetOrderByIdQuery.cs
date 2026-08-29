using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.Queries;
using Restaurant.Order.DTO.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Order.DTO.Query
{
    public class GetOrderByIdQuery : IQuery<ApiResponse<OrderDto>>
    {
        public int Id { get; set; }
    }
}
