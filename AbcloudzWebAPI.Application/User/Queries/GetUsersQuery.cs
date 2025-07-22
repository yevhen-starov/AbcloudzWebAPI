using AbcloudzWebAPI.Domain.Models;
using MediatR;
using ErrorOr;

namespace AbcloudzWebAPI.Application.User.Queries;

public record GetUsersQuery(UserFilter filter) : IRequest<ErrorOr<List<UserDomain>>>
{
}
