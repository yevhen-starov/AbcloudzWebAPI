using AbcloudzWebAPI.Application.Services;
using AbcloudzWebAPI.Domain.Models;
using System.Text.Json;

namespace AbcloudzWebAPI.Infrastructure.Services;

public class FileService : IFileService
{
    public async Task SaveUsersToFileAsync(List<UserDomain> users, string path, CancellationToken cancellationToken = default)
    {
       var directory = Path.GetDirectoryName(path);

       if (!string.IsNullOrWhiteSpace(directory) && !Directory.Exists(directory))
            Directory.CreateDirectory(directory);

        var json = JsonSerializer.Serialize(users, new JsonSerializerOptions
        {
            WriteIndented = true,
        });

        await File.WriteAllTextAsync(path, json);
    }
}
