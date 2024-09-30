using JobSearchServer.Data;

namespace JobSearchServer.Jobs;

[MutationType]
public static class JobMutations
{
    [Error<CompanyNotFoundException>]
    public static async Task<Job> AddJobAsync(
        AddJobInput input,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        var company = dbContext.Companies.Find(input.CompanyId);

        if (company == null)
        {
            throw new CompanyNotFoundException();
        }

        var job = new Job
        {
            Name = input.Name,
            CompanyId = input.CompanyId,
            ApplicationDate = DateOnly.FromDateTime(DateTime.Now),
            Confirmed = false,
            InterviewCount = 0,
            Rejected = false,
            Notes = "",
            ResumeName = "",
            CoverLetterName = "",
            JobDescription = "",
        };

        dbContext.Jobs.Add(job);

        await dbContext.SaveChangesAsync(cancellationToken);

        return job;
    }

    public static async Task<int> DeleteJobAsync(
        int jobId,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {

        var jobToBeRemoved = dbContext.Jobs.Find(jobId);
        if (jobToBeRemoved == null)
        {
            throw new JobNotFoundException();
        }
        dbContext.Jobs.Remove(jobToBeRemoved);

        await dbContext.SaveChangesAsync(cancellationToken);

        return jobId;
    }

    public static async Task<bool> UpdateJobAsync(
        UpdateJobInput input,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {

        var jobToBeChanged = dbContext.Jobs.Find(input.id);
        if (jobToBeChanged == null)
        {
            throw new JobNotFoundException();
        }

        jobToBeChanged.Confirmed = input.Confirmed ?? jobToBeChanged.Confirmed;
        jobToBeChanged.InterviewCount = input.InterviewCount ?? jobToBeChanged.InterviewCount;
        jobToBeChanged.Rejected = input.Rejected ?? jobToBeChanged.Rejected;
        jobToBeChanged.Notes = input.Notes ?? jobToBeChanged.Notes;
        jobToBeChanged.Name = input.Name ?? jobToBeChanged.Name;
        jobToBeChanged.CompanyId = input.CompanyId ?? jobToBeChanged.CompanyId;
        jobToBeChanged.ApplicationDate = input.ApplicationDate ?? jobToBeChanged.ApplicationDate;
        jobToBeChanged.ResumeName = input.ResumeName ?? jobToBeChanged.ResumeName;
        jobToBeChanged.CoverLetterName = input.CoverLetterName ?? jobToBeChanged.CoverLetterName;
        jobToBeChanged.JobDescription = input.JobDescription ?? jobToBeChanged.JobDescription;

        dbContext.SaveChanges();

        await dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}
