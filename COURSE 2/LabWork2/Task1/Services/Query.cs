namespace Task1.Services;

public class Query: IQuery
{
    private IEnumerable<Company> _companies;

        public Query(Repository repository)
        {
            _companies = repository.GetAll(); // получаем список компаний
        }
        
        
        public IEnumerable<Company> GetAllCompanies()
        {
            return _companies.OrderBy(c => c.Name); // сортирует результат по названию компании
        }

        public IEnumerable<Company> GetCompaniesByName(string name)
        {
            return _companies.Where(c => c.Name.Equals(name, StringComparison.OrdinalIgnoreCase)); // ищет компании, название которых совпадает с name
        }

        public IEnumerable<Company> GetCompaniesByProfile(BusinessProfile profile) // ищет компании с конкретным профилем
        {
            return _companies.Where(c => c.Profile == profile);
        }

        public IEnumerable<Company> GetCompaniesByProfiles(params BusinessProfile[] profiles) // ищет компании, относящиеся к одному из перечисленных профилей
        {
            return _companies.Where(c => profiles.Contains(c.Profile));
        }

        public IEnumerable<Company> GetCompaniesByEmployeeCountGreaterThan(int count) 
        {
            return _companies.Where(c => c.EmployeeCount > count); // фильтр: если employeeCount больше count
        }

        public IEnumerable<Company> GetCompaniesByEmployeeCountRange(int min, int max)
        {
            return _companies.Where(c => c.EmployeeCount >= min && c.EmployeeCount <= max); // ищет компании, количество сотрудников которых находится между min и max 
        }

        public IEnumerable<Company> GetCompaniesByCity(string city) 
        {
            return _companies.Where(c => c.Address.City.Equals(city, StringComparison.OrdinalIgnoreCase)); // ищет компании в определенном городе
        }

        public IEnumerable<Company> GetCompaniesByDirectorLastName(string lastName) 
        {
            return _companies.Where(c => c.Director.LastName.Equals(lastName, StringComparison.OrdinalIgnoreCase)); // ищет компании, чья фамилия директора совпадает
        }

        public IEnumerable<Company> GetCompaniesFoundedOverYearsAgo(int years) 
        {
            var dateThreshold = DateTime.Now.AddYears(-years);
            return _companies.Where(c => c.FoundingDate < dateThreshold); // ищет компании, основанные более N лет назад
        }

        public IEnumerable<Company> GetCompaniesFoundedOverDaysAgo(int days)
        {
            var dateThreshold = DateTime.Now.AddDays(-days);
            return _companies.Where(c => c.FoundingDate < dateThreshold); // ищет компании, основанные более N дней назад
        }
}