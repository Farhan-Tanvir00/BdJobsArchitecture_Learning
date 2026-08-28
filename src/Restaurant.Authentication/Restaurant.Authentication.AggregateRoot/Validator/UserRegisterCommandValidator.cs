using FluentValidation;
using Restaurant.Authentication.DTO.Commands;
using System;
using System.Collections.Generic;
using System.Text;

namespace Restaurant.Authentication.AggregateRoot.Validator
{
    public class UserRegisterCommandValidator : AbstractValidator<UserRegisterCommand>
    {
        public UserRegisterCommandValidator()
        {
            RuleFor(x => x.AppUserName).NotEmpty();
            RuleFor(x => x.AppUserEmail).NotEmpty().EmailAddress();
            RuleFor(X => X.AppUserPassword).NotEmpty().MinimumLength(5);
        }
    }
}
