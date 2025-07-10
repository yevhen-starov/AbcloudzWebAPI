using Abcloudz.Domain.Constants;
using Abcloudz.Domain.Entities;
using Abcloudz.Domain.Repositories.Interfaces;

namespace Abcloudz.Domain.Repositories
{
    internal class UserRepository : IUserRepository
    {
        private static IList<User> userStore = new List<User>();

        public async Task<int> CreateAsync(User user)
        {
            if (!userStore.Any())
            {
                user.Id = DomainConstants.MinId;
            }
            else
            {
                user.Id = userStore.Last().Id + 1;
            }

            userStore.Add(user);

            return await Task.FromResult(user.Id);
        }

        public async Task<IEnumerable<User>> GetAsync()
        {
            return await Task.FromResult(userStore);
        }
    }
}
