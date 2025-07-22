using AbcloudzWebAPI.Domain.Models;

namespace AbcloudzWebAPI.Application.Services;

public interface IFileService
{
    Task SaveUsersToFileAsync(List<UserDomain> users, string path, CancellationToken cancellationToken =  default);
}
