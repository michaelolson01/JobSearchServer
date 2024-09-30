namespace JobSearchServer.Jobs;

public sealed class CompanyNotFoundException() : Exception("Company not found.");
public sealed class JobNotFoundException() : Exception("Job not found.");
