using JobSearchServer.Data;
using Microsoft.EntityFrameworkCore;

namespace JobSearchServer.Companies;

public static class CompanyDataLoaders
{
    [DataLoader]
    public static async Task<IReadOnlyDictionary<int, Company>> CompanyByIdAsync(
        IReadOnlyList<int> ids,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Companies
            .AsNoTracking()
            .Where(c => ids.Contains(c.Id))
            .ToDictionaryAsync(c => c.Id, cancellationToken);
    }
}
