using JobSearchServer.Data;
using HotChocolate.Data.Filters;

namespace JobSearchServer.Companies;

public sealed class companyFilterInputType : FilterInputType<Company>
{
    protected override void Configure(IFilterInputTypeDescriptor<Company> descriptor)
    {
        descriptor.BindFieldsExplicitly();

        descriptor.Field(j => j.Name);
    }
}
