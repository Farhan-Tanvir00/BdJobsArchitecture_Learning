using FluentValidation;
using Restaurant.Management.DTO.Commands;

namespace Restaurant.Management.AggregateRoot.Validators
{
    public class ActiveDeliveryRestaurantCommandValidator : AbstractValidator<ActiveDeliveryRestaurantCommand>
    {
        public ActiveDeliveryRestaurantCommandValidator()
        {
            RuleFor(x => x.RestaurantId).NotEmpty().WithMessage("RestaurantId is required");
        }
    }
}
