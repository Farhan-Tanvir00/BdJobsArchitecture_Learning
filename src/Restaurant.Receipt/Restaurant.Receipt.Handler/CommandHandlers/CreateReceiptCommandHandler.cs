using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Receipt.AggregateRoot;
using Restaurant.Receipt.DTO.Command;
using Restaurant.Receipt.Repository.Implementation;


namespace Restaurant.Receipt.Handler.CommandHandlers
{
    public class CreateReceiptCommandHandler : ICommandHandler<CreateReceiptCommand>
    {
        private readonly ReceiptRepository _receiptRepository;
        private readonly RestaurantReceiptAggregateRoot _restaurantReceiptAggregateRoot;

        public CreateReceiptCommandHandler(ReceiptRepository receiptRepository, RestaurantReceiptAggregateRoot restaurantReceiptAggregateRoot)
        {
            _receiptRepository = receiptRepository;
            _restaurantReceiptAggregateRoot = restaurantReceiptAggregateRoot;
        }
        public async Task<ApiResponse<object?>> HandleAsync(CreateReceiptCommand command)
        {
            var receipt = _restaurantReceiptAggregateRoot.CreateReceipt(command);
            var result = await _receiptRepository.AddNewReceipt(receipt);

            if (!result)
            {
                return ApiResponse<object?>.FailedResponse("Faild to Create Receipt", 400);
            }
            return ApiResponse<object?>.SuccessResponse("Receipt Created Successfully", 200);
        }
    }
}
