using Abcloudz.Domain.Entities;

namespace Abcloudz.Domain.Repositories.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetAsync();
        Task<int> CreateAsync(User user);
    }
}
