using Restaurant.Orchestrator.DTO.Command;
using Restaurant.Orchestrator.DTO.DTO;
using Restaurant.Orchestrator.DTO.Query;
using Restaurant.Order.DTO.Commands;
using Restaurant.Receipt.DTO.Command;


namespace Restaurant.Orchestrator.AggregateRoot
{
    public class OrchestratorAggregateRoot
    {
        public CreateOrderCommand CreateOrderCommand(CreateOrderWiseReceiptCommand command)
        {
            throw new NotImplementedException();
        }

        public GetOrderByIdQuery CreateOrderQuery(int id)
        {
            throw new NotImplementedException();
        }

        public CreateReceiptCommand CreateReceiptCommand(OrderDto orderDto)
        {
            throw new NotImplementedException();
        }
    }
}
