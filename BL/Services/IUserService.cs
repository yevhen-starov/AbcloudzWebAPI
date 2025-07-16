using AbcloudzWebAPI.BL.Models;
using AbcloudzWebAPI.BL.Models.Clients.Request;

namespace AbcloudzWebAPI.BL.Services;

public interface IUserService
{
    Task<List<UserModel>> GetUsers();

    Task<long> CreateUser(UserRequest user);
}
