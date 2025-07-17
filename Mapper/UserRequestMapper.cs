using AbcloudzWebAPI.Contracts.User;
using AbcloudzWebAPI.Domain.Models;
using System.Runtime.CompilerServices;

namespace AbcloudzWebAPI.Mapper;

public static class UserRequestMapper
{
    public static User ToDomain(this UserRequest request)
        => new User
        {
            Id = Guid.NewGuid(),
            Name = request.UserName,
            Email = request.Email,
            Password = request.Password,
        };     
}
