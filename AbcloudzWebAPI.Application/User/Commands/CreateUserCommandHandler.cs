using AbcloudzWebAPI.Application.Services;
using AbcloudzWebAPI.Domain.Models;
using ErrorOr;
using MediatR;

namespace AbcloudzWebAPI.Application.User.Commands;

public class CreateUserCommandHandler(IUserService userService) : IRequestHandler<CreateUserCommand, ErrorOr<UserDomain>>
{
    private readonly IUserService _userService = userService;
    public async Task<ErrorOr<UserDomain>> Handle(CreateUserCommand request, CancellationToken cancellationToken)
    {
        var validator = new CreateUserCommandValidator();

        var validationResult = await validator.ValidateAsync(request, cancellationToken);

        if (!validationResult.IsValid)
        {
            return validationResult.Errors
                .Select(error => Error.Validation(code: error.PropertyName, description: error.ErrorMessage))
                .ToList();
        }

        return await _userService.CreateUserAsync(request.user);
    }
}
