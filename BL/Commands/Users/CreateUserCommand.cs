using AbcloudzWebAPI.BL.Models;
using MediatR;

namespace AbcloudzWebAPI.BL.Commands.Users;

public class CreateUserCommand : IRequest<long>
{
    public CreateUserCommand(UserModel user)
    {
        User = user ?? throw new ArgumentNullException(nameof(user));
    }

    public UserModel User { get; }
}
