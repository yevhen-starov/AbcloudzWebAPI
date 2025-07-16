using AbcloudzWebAPI.BL.Models;
using AbcloudzWebAPI.BL.Models.Clients.Request;
using AutoMapper;

namespace AbcloudzWebAPI.BL.Services;

public class UserService : IUserService
{
    private readonly IMapper _mapper;
    private static readonly List<UserModel> Users = new List<UserModel>();

    public UserService(IMapper mapper)
    {
        _mapper = mapper;
    }


    public Task<List<UserModel>> GetUsers()
    {
        var users = Users;
        
        return Task.FromResult(users);
    }

    public Task<long> CreateUser(UserRequest user)
    {
        var maxItems = Users.Max(x => x.Id);

        var userModel = _mapper.Map<UserModel>(user);
        userModel.Id = maxItems + 1;
        Users.Add(userModel);

        return Task.FromResult(userModel.Id);
    }
}
