using FluentValidation;

namespace AbcloudzWebAPI.Application.User.Queries;

public class GetUserQueryValidator : AbstractValidator<GetUsersQuery>
{
    public GetUserQueryValidator()
    {
        RuleFor(uf => uf.filter.Page)
           .GreaterThanOrEqualTo(1)
           .WithMessage("Page must be at least 1");

        RuleFor(uf => uf.filter.PageSize)
            .InclusiveBetween(1, 20)
            .WithMessage("Page size mest be from 1 to 20");
    }
}
