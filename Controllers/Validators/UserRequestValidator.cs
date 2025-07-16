using AbcloudzWebAPI.BL.Models.Clients.Request;
using FluentValidation;

namespace AbcloudzWebAPI.Controllers.Validators;

public class UserRequestValidator : AbstractValidator<UserRequest>
{
    public UserRequestValidator()
    {
    }
}
