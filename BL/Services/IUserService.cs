using AbcloudzWebAPI.BL.Models;
using AbcloudzWebAPI.BL.Models.Clients.Request;
using AbcloudzWebAPI.BL.Models.Clients.Requests;

namespace AbcloudzWebAPI.BL.Services;

public interface IUserService
{
    Task<IReadOnlyCollection<UserModel>> GetUsers(GetUsersRequest getUsersRequest);

    Task<long> CreateUser(CreateUserRequest user);
}
