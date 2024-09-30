using JobSearchServer.Data;
using JobSearchServer.Companies;

namespace JobSearchServer.Jobs;

[ObjectType<Job>]
public static partial class JobType
{
    static partial void Configure(IObjectTypeDescriptor<Job> descriptor)
    {
        descriptor
            .Field(s => s.Id)
            .ID();
    }

    // [BindMember(nameof(Job.Company))]
    // public static async Task<Company> GetCompanyAsync(
    //     [Parent] Company company,
    //     ICompanyByIdDataLoader companyBySessionId,
    //     CancellationToken cancellationToken)
    // {
    //     return await companyBySessionId.LoadRequiredAsync(company.Id, cancellationToken);
    // }
}
