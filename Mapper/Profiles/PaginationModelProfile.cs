using AbcloudzWebAPI.BL.Models;
using AbcloudzWebAPI.BL.Models.Clients.Requests;
using AutoMapper;

namespace AbcloudzWebAPI.Mapper.Profiles;

public class PaginationModelProfile : Profile
{
    public PaginationModelProfile()
    {
        _ = CreateMap<GetUsersRequest, PaginationModel>();
    }
}
