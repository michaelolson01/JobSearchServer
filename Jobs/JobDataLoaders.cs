using Microsoft.EntityFrameworkCore;
using JobSearchServer.Data;

namespace JobSearchServer.Jobs;

public static class JobDataLoaders
{
    [DataLoader]
    public static async Task<IReadOnlyDictionary<int, Job>> JobByIdAsync(
        IReadOnlyList<int> ids,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Jobs
            .AsNoTracking()
            .Where(j => ids.Contains(j.Id))
            .ToDictionaryAsync(j => j.Id, cancellationToken);
    }

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

