using AbcloudzWebAPI.Contracts.User;
using FluentValidation;

namespace AbcloudzWebAPI.Validator;

public class UserFilterValidator : AbstractValidator<UserFilter>
{
    public UserFilterValidator()
    {
        RuleFor(uf => uf.Page)
            .GreaterThanOrEqualTo(1)
            .WithMessage("Page must be at least 1");

        RuleFor(uf => uf.PageSize)
            .InclusiveBetween(1, 20)
            .WithMessage("Page size mest be from 1 to 20");
    }
}
