using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Orchestrator.DTO.Command;
using Restaurant.Orchestrator.DTO.Service;
using Restaurant.Order.DTO.DTO;
using Restaurant.Order.DTO.Query;
using Restaurant.ServiceBus.Implementation;

namespace Restaurant.Orchestrator.Handler.CommandHandlers
{
    public class CreateOrderWithReceiptCommandHandler : ICommandHandler<CreateOrderWithReceiptCommand>
    {
        private readonly GenericServiceBus _serviceBus;
        public CreateOrderWithReceiptCommandHandler(GenericServiceBus serviceBus)
        {
            _serviceBus = serviceBus;
        }
        public async Task<ApiResponse<object?>> HandleAsync(CreateOrderWithReceiptCommand command)
        {
            var orderCommand = OrchestratorService.CreateOrderCommand(command);
            var createOrderResponse = await _serviceBus.SendCommandAsync(orderCommand);

            if (!createOrderResponse.Success)
            {
                return ApiResponse<object?>.FailedResponse(createOrderResponse.Data, createOrderResponse.Message!, createOrderResponse.StatusCode);
            }

            var orderQuery = OrchestratorService.CreateOrderQuery(createOrderResponse.CreatedWithId);
            var OrderApiResponse = await _serviceBus.SendQueryAsync<GetOrderByIdQuery, ApiResponse<OrderDto>>(orderQuery);

            var receiptCommand = OrchestratorService.CreateReceiptCommand(OrderApiResponse.Data!);
            var createReceiptResponse = await _serviceBus.SendCommandAsync(receiptCommand);
            if (!createReceiptResponse.Success)
            {
                return ApiResponse<object?>.FailedResponse(createOrderResponse.Data, createReceiptResponse.Message!, createOrderResponse.StatusCode);
            }

            return ApiResponse<object?>.SuccessResponse("Order and Receipt Created", 200);
        }
    }
}
