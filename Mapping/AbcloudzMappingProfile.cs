using Abcloudz.Domain.Entities;
using AbcloudzWebAPI.DTO;
using AutoMapper;

namespace AbcloudzWebAPI.Mapping
{
    public class AbcloudzMappingProfile : Profile
    {
        public AbcloudzMappingProfile()
        {
            CreateMap<User, UserDto>().ReverseMap();
        }
    }
}
