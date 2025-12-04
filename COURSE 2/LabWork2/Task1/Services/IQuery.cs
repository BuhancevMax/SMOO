namespace Task1.Services;

public interface IQuery
{
    IEnumerable<Company> GetAllCompanies();
    IEnumerable<Company> GetCompaniesByName(string name);
    IEnumerable<Company> GetCompaniesByProfile(BusinessProfile profile);
    IEnumerable<Company> GetCompaniesByProfiles(params BusinessProfile[] profiles);
    IEnumerable<Company> GetCompaniesByEmployeeCountGreaterThan(int count);
    IEnumerable<Company> GetCompaniesByEmployeeCountRange(int min, int max);
    IEnumerable<Company> GetCompaniesByCity(string city);
    IEnumerable<Company> GetCompaniesByDirectorLastName(string lastName);
    IEnumerable<Company> GetCompaniesFoundedOverYearsAgo(int years);
    IEnumerable<Company> GetCompaniesFoundedOverDaysAgo(int days);
}