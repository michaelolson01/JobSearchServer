using JobSearchServer.Data;
using Microsoft.EntityFrameworkCore;

namespace JobSearchServer.Jobs;

public static class JobQueries
{

    [Query]
    [UseProjection]
    public static async Task<IEnumerable<Job>> GetJobsAsync(
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        return await dbContext.Jobs.ToListAsync(cancellationToken);
    }

    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Job> GetJobs(ApplicationDbContext dbContext)
    {
        return dbContext.Jobs.AsNoTracking().OrderBy(j => j.Name);
    }

    [Query]
    public static async Task<Job?> GetJobAsync(
        int id,
        IJobByIdDataLoader jobById,
        CancellationToken cancellationToken)
    {
        return await jobById.LoadAsync(id, cancellationToken);
    }
}

