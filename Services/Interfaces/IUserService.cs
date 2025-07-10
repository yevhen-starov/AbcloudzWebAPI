using Abcloudz.Domain.Entities;
using AbcloudzWebAPI.DTO;

namespace AbcloudzWebAPI.Services.Interfaces
{
    public interface IUserService
    {
        Task<IEnumerable<UserDto>> GetAsync();
        Task<int> CreateAsync(UserDto user);
    }
}
