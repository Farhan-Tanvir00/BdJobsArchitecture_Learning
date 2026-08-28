using FluentValidation;
using FluentValidation.Validators;
using Restaurant.Authentication.DTO.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Authentication.AggregateRoot.Validator
{
    public class UserLoginCommandValidator : AbstractValidator<UserLoginCommand>
    {
        public UserLoginCommandValidator()
        {
            RuleFor(x => x.AppUserName).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
