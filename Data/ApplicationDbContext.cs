using Microsoft.EntityFrameworkCore;

namespace JobSearchServer.Data;

public sealed class ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
    : DbContext(options)
{
    public DbSet<Company> Companies { get; init; }

    public DbSet<Job> Jobs { get; init; }

}
