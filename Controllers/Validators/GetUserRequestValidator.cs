using AbcloudzWebAPI.BL.Models.Clients.Requests;
using FluentValidation;

namespace AbcloudzWebAPI.Controllers.Validators;

public class GetUserRequestValidator : AbstractValidator<GetUsersRequest>
{
    public GetUserRequestValidator()
    {
        _ = RuleFor(x => x.PageSize).GreaterThan(0);
        _ = RuleFor(x => x.PageNumber).GreaterThan(0);
    }
}
