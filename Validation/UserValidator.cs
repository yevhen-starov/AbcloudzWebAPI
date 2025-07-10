using AbcloudzWebAPI.DTO;
using FluentValidation;

namespace AbcloudzWebAPI.Validation
{
    public class UserValidator : AbstractValidator<UserDto>
    {
        public UserValidator()
        {
            RuleFor(x => x.Age).GreaterThan(0);
            RuleFor(x => x.Email)
                .NotEmpty().WithMessage("Email is required")
                .EmailAddress().WithMessage("Email is not valid");
        }
    }
}
