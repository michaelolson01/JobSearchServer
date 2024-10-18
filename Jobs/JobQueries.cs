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
        // Get the jobs, and wait for the query to finish.
        var jobs = await dbContext.Jobs.ToListAsync(cancellationToken);
        // Add the company to each of the jobs (if it is findable)
        foreach (var j in jobs)
        {
            // Attempt to get the company
            var company = dbContext.Companies.AsNoTracking().First(c => c.Id == j.CompanyId);
            if (company is not null)
            {
                j.Company = company;
            }
        }
        // Return the jobs with the companies embedded in them.
        return jobs;
    }

    [UsePaging]
    [UseFiltering]
    [UseSorting]
    public static IQueryable<Job> GetJobs(ApplicationDbContext dbContext)
    {
        // This should also look up the company and return it with it.
        var jobs = dbContext.Jobs.AsNoTracking().OrderBy(j => j.Name);
        foreach (var j in jobs)
        {
            var company = dbContext.Companies.AsNoTracking().First(c => c.Id == j.CompanyId);
            Console.WriteLine(company);
            if (company is null)
            {
                // If there is no company, don't change anything.
                continue;
            }
            j.Company = company;
        }
        return jobs;
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

