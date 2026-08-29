using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Order.DTO.DTO;
using Restaurant.Order.DTO.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Order.Handler.QueryHandler
{
    public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, OrderDto>
    {
        public Task<OrderDto> HandleAsync(GetOrderByIdQuery query)
        {
            throw new NotImplementedException();
        }
    }
}
