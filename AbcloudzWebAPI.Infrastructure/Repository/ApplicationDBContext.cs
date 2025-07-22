using AbcloudzWebAPI.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace AbcloudzWebAPI.Infrastructure.Repository;

public class ApplicationUserDBContext : DbContext
{
    public DbSet<UserDomain> Users { get; set; } = null!;

    public ApplicationUserDBContext(DbContextOptions<ApplicationUserDBContext> options) : base(options)
    {
    }
}
