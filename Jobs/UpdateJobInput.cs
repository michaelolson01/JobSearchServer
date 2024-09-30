namespace JobSearchServer.Jobs;

public sealed record UpdateJobInput(
    int id,
    string? Name,
    int? CompanyId,
    DateOnly? ApplicationDate,
    bool? Confirmed,
    int? InterviewCount,
    bool? Rejected,
    string? Notes,
    string? ResumeName,
    string? CoverLetterName,
    string? JobDescription);
