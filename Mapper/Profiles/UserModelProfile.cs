using AbcloudzWebAPI.BL.Models;
using AbcloudzWebAPI.BL.Models.Clients.Request;
using AutoMapper;

namespace AbcloudzWebAPI.Mapper.Profiles;

public class UserModelProfile : Profile
{
    public UserModelProfile()
    {
        _ = CreateMap<CreateUserRequest, UserModel>()
            .ForMember(x => x.Id, opt => opt.Ignore());
    }
}
