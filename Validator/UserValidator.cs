using AbcloudzWebAPI.Contracts.User;
using FluentValidation;

namespace AbcloudzWebAPI.Validator;

public class UserValidator : AbstractValidator<UserRequest>
{
    public UserValidator()
    {
        RuleFor(u => u.UserName)
            .NotEmpty()
            .WithMessage("Name must be not empty");

        RuleFor(u => u.Password)
            .NotEmpty()
            .MinimumLength(255)
            .WithMessage("Password is not valid");

        RuleFor(u => u.Email)
            .EmailAddress()
            .WithMessage("Email is not valid");
    }
}
