using FluentValidation;
using Restaurant.Order.DTO.Commands;

namespace Restaurant.Order.AggregateRoot.Validations
{
    public class CreateOrderCommandValidator : AbstractValidator<CreateOrderCommand>
    {
        public CreateOrderCommandValidator()
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

            RuleForEach(x => x.LineItems)
                .SetValidator(new CreateOrderLineItemCommandValidator());
        }
    }

    public class CreateOrderLineItemCommandValidator : AbstractValidator<CreateOrderLineItemCommand>
    {
        public CreateOrderLineItemCommandValidator()
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
        }
    }
}
