using AbcloudzWebAPI.Domain.Models;
using ErrorOr;
using MediatR;

namespace AbcloudzWebAPI.Application.User.Commands;

public record CreateUserCommand(UserDomain user) : IRequest<ErrorOr<UserDomain>>
{
}
