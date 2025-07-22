using AbcloudzWebAPI.Application.Common.Interfaces;
using AbcloudzWebAPI.Application.User;
using AbcloudzWebAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AbcloudzWebAPI.Infrastructure.Repository;

public class UserRepository(ApplicationUserDBContext dbContext) : IUserRepository
{
    ApplicationUserDBContext _dbContext = dbContext;
 
    public async Task<UserDomain> CreateUserAsync(UserDomain user)
    {
        if (user is null)
            throw new ArgumentNullException(nameof(user));

        _dbContext.Users.Add(user);

        await _dbContext.SaveChangesAsync();

        return user;

    }

    public async Task<List<UserDomain>> GetAllAsync(UserFilter filter)
    {
        var query = _dbContext.Users.AsQueryable();

        if (!string.IsNullOrWhiteSpace(filter.Search))
            query = query.Where(u => u.Name.Contains(filter.Search) || u.Email.Contains(filter.Search));

        query = query.OrderBy(u => u.Name)
            .Skip((filter.Page - 1) * filter.PageSize)
            .Take(filter.PageSize);

        return await query.ToListAsync();
    }

}
