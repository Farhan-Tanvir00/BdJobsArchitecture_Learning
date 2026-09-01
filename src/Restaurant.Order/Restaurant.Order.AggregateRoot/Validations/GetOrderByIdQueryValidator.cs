using FluentValidation;
using Restaurant.Order.DTO.Query;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Order.AggregateRoot.Validations
{
    public class GetOrderByIdQueryValidator : AbstractValidator<GetOrderByIdQuery>
    {
        public GetOrderByIdQueryValidator()
        {
            RuleFor(x => x.Id)
                .GreaterThan(0)
                .WithMessage("Order ID must be greater than 0.");
        }
    }
}
