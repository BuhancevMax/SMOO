using Task1;
using Task1.Services;
using Task1.Utils;

class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        Repository repository = new Repository();
        Query queryService = new Query(repository); 
        
        QueryHelper.DisplayResults(
            "1. Всі фірми (відсортовані за назвою)",
            queryService.GetAllCompanies()
        );
        
        QueryHelper.DisplayResults(
            "2. Фірми з назвою 'Food Express Ltd'",
            queryService.GetCompaniesByName("Food Express Ltd")
        );
        
        QueryHelper.DisplayResults(
            "3. Фірми, що працюють у галузі Marketing",
            queryService.GetCompaniesByProfile(BusinessProfile.Marketing)
        );
        
        QueryHelper.DisplayResults(
            "4. Фірми, що працюють у галузі Marketing або IT",
            queryService.GetCompaniesByProfiles(BusinessProfile.Marketing, BusinessProfile.IT)
        );
        
        QueryHelper.DisplayResults(
            "5. Фірми з кількістю співробітників > 100",
            queryService.GetCompaniesByEmployeeCountGreaterThan(100)
        );
        
        QueryHelper.DisplayResults(
            "6. Фірми з кількістю співробітників у діапазоні [100; 300]",
            queryService.GetCompaniesByEmployeeCountRange(100, 300)
        );
        
        QueryHelper.DisplayResults(
            "7. Фірми, що знаходяться у Лондоні",
            queryService.GetCompaniesByCity("London")
        );
        
        QueryHelper.DisplayResults(
            "8. Фірми, які мають прізвище директора White",
            queryService.GetCompaniesByDirectorLastName("White")
        );
        
        QueryHelper.DisplayResults(
            "9. Фірми, які засновані понад 2 роки тому",
            queryService.GetCompaniesFoundedOverYearsAgo(2)
        );
        
        QueryHelper.DisplayResults(
            "10. Фірми, з дня заснування яких минуло більше 150 днів",
            queryService.GetCompaniesFoundedOverDaysAgo(150)
        );
    }
}