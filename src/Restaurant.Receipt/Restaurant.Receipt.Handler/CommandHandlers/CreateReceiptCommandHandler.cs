using FluentValidation;
using Restaurant.Management.Shared.Common;
using Restaurant.Management.Shared.Interfaces.GenericCommandQueryHandler;
using Restaurant.Receipt.AggregateRoot;
using Restaurant.Receipt.DTO.Command;
using Restaurant.Receipt.Repository.Implementation;
using Restaurant.Shared.Exceptions;


namespace Restaurant.Receipt.Handler.CommandHandlers
{
    public class CreateReceiptCommandHandler : ICommandHandler<CreateReceiptCommand>
    {
        private readonly ReceiptRepository _receiptRepository;
        private readonly RestaurantReceiptAggregateRoot _restaurantReceiptAggregateRoot;
        private readonly IValidator<CreateReceiptCommand> _validator;

        public CreateReceiptCommandHandler(ReceiptRepository receiptRepository, RestaurantReceiptAggregateRoot restaurantReceiptAggregateRoot,
            IValidator<CreateReceiptCommand> validator)
        {
            _receiptRepository = receiptRepository;
            _restaurantReceiptAggregateRoot = restaurantReceiptAggregateRoot;
            _validator = validator;
        }
        public async Task<ApiResponse<object?>> HandleAsync(CreateReceiptCommand command)
        {
            var validationResult = await _validator.ValidateAsync(command);
            if (!validationResult.IsValid)
            {
                var validationErrors = validationResult.ToDictionary();
                return ApiResponse<object?>.FailedResponse(validationErrors, "Validation failed", 400);
            }

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
