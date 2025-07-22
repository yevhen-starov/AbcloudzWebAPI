using FluentValidation;

namespace AbcloudzWebAPI.Application.User.Commands;

public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
{
    public CreateUserCommandValidator()
    {
        RuleFor(u => u.user.Name)
            .MinimumLength(2)
            .MaximumLength(100);


        RuleFor(u => u.user.Password)
            .NotEmpty()
            .MaximumLength(255)
            .WithMessage("Password is not valid");

        RuleFor(u => u.user.Email)
            .EmailAddress()
            .WithMessage("Email is not valid");
    }
}
