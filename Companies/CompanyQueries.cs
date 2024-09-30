using JobSearchServer.Data;
using Microsoft.EntityFrameworkCore;

namespace JobSearchServer.Companies;

public static class Queries
{
    [Query]
    public static async Task<IEnumerable<Company>> GetCompaniesAsync(
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Companies.AsNoTracking().ToListAsync(cancellationToken);
    }

    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Company> GetCompanies(ApplicationDbContext dbContext)
    {
        return dbContext.Companies.AsNoTracking().OrderBy(c => c.Name);
    }

    [Query]
    public static async Task<Company?> GetCompanyAsync(
        int id,
        ICompanyByIdDataLoader companyById,

        ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await companyById.LoadAsync(id, cancellationToken);
    }
}

