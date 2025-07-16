using AbcloudzWebAPI.BL.Models;
using AbcloudzWebAPI.BL.Models.Clients.Request;
using AutoMapper;

namespace AbcloudzWebAPI.Mapper.Profiles;

public class UserModelProfile : Profile
{
    public UserModelProfile()
    {
        _ = CreateMap<UserRequest, UserModel>()
            .ForMember(x => x.Id, opt => opt.Ignore());
    }
}
