using AbcloudzWebAPI.Domain.Models;
using AbcloudzWebAPI.Application.User;
using ErrorOr;


namespace AbcloudzWebAPI.Application.Services;

public interface IUserService
{
    public Task<ErrorOr<UserDomain>> CreateUserAsync(UserDomain user);
    public Task<List<UserDomain>> GetUsersAsync(UserFilter filter);

}
