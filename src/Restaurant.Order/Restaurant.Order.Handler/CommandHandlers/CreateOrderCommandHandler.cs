using FluentValidation;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Order.AggregateRoot;
using Restaurant.Order.DTO.Commands;
using Restaurant.Order.Repository.Implementations;
using Restaurant.Shared.Exceptions;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Order.Handler.CommandHandlers
{
    public class CreateOrderCommandHandler : ICommandHandler<CreateOrderCommand>
    {
        private readonly OrderAggregateRoot _orderAggregateRoot;
        private readonly OrderRepository _orderRepository;
        private readonly IValidator<CreateOrderCommand> _validator;
        public CreateOrderCommandHandler(OrderAggregateRoot orderAggregateRoot, OrderRepository orderRepository, IValidator<CreateOrderCommand> validator)
        {
            _orderAggregateRoot = orderAggregateRoot;
            _orderRepository = orderRepository;
            _validator = validator;
        }
        public async Task<ApiResponse<object?>> HandleAsync(CreateOrderCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                var validationErrors = validationResult.ToDictionary();
                return ApiResponse<object?>.FailedResponse(validationErrors, "Validation failed", 400);

            }

            var order = _orderAggregateRoot.CreateOrder(command);
            var (success, OrdeId) = await _orderRepository.AddNewOrder(order);

            if (!success)
            {
                return ApiResponse<object?>.FailedResponse("Faild saving Order", 400);
            }

            return ApiResponse<object?>.SuccessResponse("Order Saved Successfully", 201, order.Id);
        }
    }
}
