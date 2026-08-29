using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Order.AggregateRoot;
using Restaurant.Order.DTO.DTO;
using Restaurant.Order.DTO.Query;
using Restaurant.Order.Repository.Implementations;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Order.Handler.QueryHandler
{
    public class GetOrderByIdQueryHandler : IQueryHandler<GetOrderByIdQuery, ApiResponse<OrderDto>>
    {
        private readonly OrderAggregateRoot _orderAggregateRoot;
        private readonly OrderRepository _orderRepository;
        public GetOrderByIdQueryHandler(OrderAggregateRoot orderAggregateRoot, OrderRepository orderRepository)
        {
            _orderAggregateRoot = orderAggregateRoot;
            _orderRepository = orderRepository;
        }
        public async Task<ApiResponse<OrderDto>> HandleAsync(GetOrderByIdQuery query)
        {
            var order = await _orderRepository.GetOrderByIdAsync(query.Id);
            if(order == null)
            {
                return ApiResponse<OrderDto>.FailedResponse("Faild saving Order", 400);
            }

            var orderDto = _orderAggregateRoot.GetOrderDto(order);

            return ApiResponse<OrderDto>.SuccessResponse(orderDto, "Order Retrieve Successful", 200);
        }
    }
}
