using System.ComponentModel.DataAnnotations;

namespace JobSearchServer.Data;

public sealed class Company
{
    [Key]
    public int Id { get; init; }

    public required string Name { get; init; }

    // List of jobs that are from this company
    // Collection Naviagation containing dependents
    public ICollection<Job> Jobs { get; set; } = new List<Job>();
}
