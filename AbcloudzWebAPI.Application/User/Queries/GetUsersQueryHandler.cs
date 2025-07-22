using AbcloudzWebAPI.Application.Services;
using AbcloudzWebAPI.Domain.Models;
using MediatR;
using ErrorOr;

namespace AbcloudzWebAPI.Application.User.Queries;

public class GetUsersQueryHandler(IUserService userService) : IRequestHandler<GetUsersQuery, ErrorOr<List<UserDomain>>>
{
    private readonly IUserService _userService = userService;
    public async Task<ErrorOr<List<UserDomain>>> Handle(GetUsersQuery request, CancellationToken cancellationToken)
    {
        var validator = new GetUserQueryValidator();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return validationResult.Errors
                .Select(error => Error.Validation(code: error.PropertyName, description: error.ErrorMessage))
                .ToList();
        }

        return  await _userService.GetUsersAsync(request.filter);
    }
}
