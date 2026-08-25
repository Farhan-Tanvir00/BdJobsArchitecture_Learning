using FluentValidation;
using Restaurant.Management.DTO.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Management.AggregateRoot.Validators
{
    public class UpdateRestaurantCommandValidator : AbstractValidator<UpdateRestaurantCommand>
    {
        public UpdateRestaurantCommandValidator()
        {
            RuleFor(x => x.RestaurantName).NotEmpty();
            RuleFor(x => x.RestaurantDescription).NotEmpty();
            RuleFor(x => x.RestaurantCategory).NotEmpty().Must(category => category == "Bangali" || category == "Thai" || category == "Chainese")
                .WithMessage("Category must be in ('Bangali' or 'Thai' or 'Chainese')");
            RuleFor(x => x.RestaurantContactEmail).EmailAddress();
            RuleFor(x => x.RestaurantContactNumber).Matches(@"^(?:\+88|88)?(01[3-9]\d{8})$")
                .WithMessage("Provide a valid phone number");
        }
    }
}
