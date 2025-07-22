using AbcloudzWebAPI.Application.Common.Interfaces;
using AbcloudzWebAPI.Application.Services;
using AbcloudzWebAPI.Application.User;
using AbcloudzWebAPI.Domain.Errors;
using AbcloudzWebAPI.Domain.Models;
using ErrorOr;
using Microsoft.EntityFrameworkCore;

namespace AbcloudzWebAPI.Infrastructure.Services;

public class UserService(IUserRepository userRepository) : IUserService
{
    IUserRepository _userRepository = userRepository;

    public async Task<ErrorOr<UserDomain>> CreateUserAsync(UserDomain user)
    {
        if (user is null)
            return UserErrors.Null;
        try
        {
            var created = await _userRepository.CreateUserAsync(user);

            // TODO: сначала запись потом проверка
            if (string.IsNullOrWhiteSpace(created.Email))
                return UserErrors.InvalidEmail;

            return created;
        }
        catch (DbUpdateException ex)
        {
            return UserErrors.CreateFailed(ex.Message);
        }
         
    }
        
    public async Task<List<UserDomain>> GetUsersAsync(UserFilter filter)  
        => await _userRepository.GetAllAsync(filter);    
}
