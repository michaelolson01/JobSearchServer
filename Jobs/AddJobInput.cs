namespace JobSearchServer.Jobs;

public sealed record AddJobInput(
    string Name,
    int CompanyId);

