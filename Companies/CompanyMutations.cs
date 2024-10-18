using JobSearchServer.Data;

namespace JobSearchServer.Companies;

[MutationType]
public static class CompanyMutations
{
    public static async Task<Company> AddCompanyAsync(
        AddCompanyInput input,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {
        var company = new Company
        {
            Name = input.Name,
        };

        dbContext.Companies.Add(company);

        await dbContext.SaveChangesAsync(cancellationToken);

        return company;
    }

    public static async Task<bool> DeleteCompanyAsync(
        int companyId,
        ApplicationDbContext dbContext,
        CancellationToken cancellationToken)
    {

        var companyToBeRemoved = await dbContext.Companies.FindAsync(cancellationToken, companyId);
        if (companyToBeRemoved != null)
        {
            dbContext.Companies.Remove(companyToBeRemoved);
        }
        else
        {
            Console.WriteLine("Requested company did not exist");
            return false;
        }

        await dbContext.SaveChangesAsync(cancellationToken);

        return true;
    }
}

