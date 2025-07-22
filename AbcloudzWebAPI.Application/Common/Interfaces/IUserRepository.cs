using AbcloudzWebAPI.Application.User;
using AbcloudzWebAPI.Domain.Models;

namespace AbcloudzWebAPI.Application.Common.Interfaces;

public interface IUserRepository
{
    public Task<UserDomain> CreateUserAsync(UserDomain user);
    public Task<List<UserDomain>> GetAllAsync(UserFilter filter);
}
