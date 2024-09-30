using System.ComponentModel.DataAnnotations;

namespace JobSearchServer.Data;

public sealed class Job
{
    [Key]
    public int Id { get; init; }

    public DateOnly ApplicationDate { get; set; }

    public required string Name { get; set; }

    public bool Confirmed { get; set; }

    public int InterviewCount { get; set; }

    public bool Rejected { get; set; }

    public string? Notes { get; set; }

    public string? ResumeName { get; set; }

    public string? CoverLetterName { get; set; }

    public string? JobDescription { get; set; }

    // Company Foreign Key
    // Required foreign key property
    public int CompanyId { get; set; }

    // Required company for the job.
    // Required reference navigation to principal
    public Company Company { get; set; } = null!;
}
