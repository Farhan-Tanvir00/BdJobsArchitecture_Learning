using FluentValidation;
using Restaurant.Receipt.DTO.Command;

namespace Restaurant.Receipt.AggregateRoot.Validations
{
    public class CreateReceiptCommandValidator : AbstractValidator<CreateReceiptCommand>
    {
        public CreateReceiptCommandValidator()
        {
            RuleFor(x => x.RestaurantCustomerId)
                .GreaterThan(0)
                .WithMessage("Restaurant customer ID must be greater than 0.");

            RuleFor(x => x.TargetRestaurantId)
                .GreaterThan(0)
                .WithMessage("Target restaurant ID must be greater than 0.");

            RuleFor(x => x.CustomerShippingAddress)
                .NotEmpty()
                .WithMessage("Customer shipping address is required.");

            RuleFor(x => x.LineItems)
                .NotEmpty()
                .WithMessage("At least one receipt item is required.");

            RuleForEach(x => x.LineItems).SetValidator(new CreateReceiptLineItemCommandValidator());

            RuleFor(x => x.TotalCost).GreaterThan(0).WithMessage("Total cost must be greater than 0.");
        }

        public class CreateReceiptLineItemCommandValidator : AbstractValidator<CreateReceiptLineItemCommand>
        {
            public CreateReceiptLineItemCommandValidator()
            {
                RuleFor(x => x.RestaurantDishId)
                    .GreaterThan(0)
                    .WithMessage("Restaurant dish ID must be greater than 0.");
                RuleFor(x => x.OrderedQuantity)
                    .GreaterThan(0)
                    .WithMessage("Ordered quantity must be greater than 0.");
                RuleFor(x => x.DishUnitPrice)
                    .GreaterThan(0)
                    .WithMessage("Dish unit price must be greater than 0.");
                RuleFor(x => x.LineTotal)
                    .GreaterThan(0)
                    .WithMessage("Line total must be greater than 0.");
            }
        }

    }
}
