using JobSearchServer.Data;
using HotChocolate.Data.Filters;

namespace JobSearchServer.Jobs;

public sealed class jobFilterInputType : FilterInputType<Job>
{
    protected override void Configure(IFilterInputTypeDescriptor<Job> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(j => j.Name);
        descriptor.Field(j => j.Confirmed);
        descriptor.Field(j => j.InterviewCount);
        descriptor.Field(j => j.Rejected);

        // I wonder how this will work for Company and Temp Agency?
    }
}
