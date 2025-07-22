using AbcloudzWebAPI.Contracts.User;
using AbcloudzWebAPI.Domain.Models;

namespace AbcloudzWebAPI.Mapper;

public static class UserMapper
{
    public static UserResponse ToResonse(this UserDomain user)
        =>
        new UserResponse
        {
            UserId = user.Id,
            UserName = user.Name
        };

    public static List<UserResponse> ToResponseList(this IEnumerable<UserDomain> users)
        => users.Select(u => u.ToResonse()).ToList();
}
