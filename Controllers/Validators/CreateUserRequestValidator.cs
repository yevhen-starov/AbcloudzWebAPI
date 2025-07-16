﻿using AbcloudzWebAPI.BL.Models.Clients.Request;
using FluentValidation;

namespace AbcloudzWebAPI.Controllers.Validators;

public class CreateUserRequestValidator : AbstractValidator<CreateUserRequest>
{
    public CreateUserRequestValidator()
    {
        _ = RuleFor(x => x.Name).NotEmpty();
        _ = RuleFor(x => x.Surname).NotEmpty();
        _ = RuleFor(x => x.Email).EmailAddress();
    }
}
