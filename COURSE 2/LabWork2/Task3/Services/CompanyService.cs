using Task3.Models;

namespace Task3
{
    public class CompanyService
    {
        private IEnumerable<Employer> _employers;

        public CompanyService(IEnumerable<Employer> employers)
        {
            _employers = employers;
        }
        
        public int GetTotalEmployeeCount()
        {
            return _employers.Count();
        }
        
        public decimal GetTotalSalaryPayout()
        {
            return _employers.Sum(e => e.Salary);
        }
        
        public Employer? GetYoungestEducatedVeteran()
        {
            return _employers
                .OrderByDescending(e => e.WorkExperience)
                .Take(10)
                .Where(e => e.HasHigherEducation)
                .OrderBy(e => e.Age)
                .FirstOrDefault();
        }
        
        public (Manager Youngest, Manager Oldest) GetYoungestAndOldestManagers()
        {
            var managers = _employers.OfType<Manager>();
            if (!managers.Any())
            {
                return (null, null);
            }

            var youngest = managers.OrderBy(m => m.Age).FirstOrDefault();
            var oldest = managers.OrderByDescending(m => m.Age).FirstOrDefault();

            return (youngest, oldest);
        }
        
        public IEnumerable<IGrouping<string, Employer>> GetEmployeesBornInOctober()
        {
            return _employers
                .Where(e => e.DateOfBirth.Month == 10)
                .GroupBy(e => e.GetType().Name);
        }
        
        public (IEnumerable<Employer> AllVolodymyrs, Employer? Youngest, decimal? Bonus) AnalyzeVolodymyrs()
        {
            var volodymyrs = _employers
                .Where(e => e.FirstName.Equals("Володимир", StringComparison.OrdinalIgnoreCase));

            if (!volodymyrs.Any())
            {
                return (volodymyrs, null, null);
            }

            var youngestVolodymyr = volodymyrs.OrderBy(e => e.Age).FirstOrDefault();
            var bonus = youngestVolodymyr?.Salary / 3;

            return (volodymyrs, youngestVolodymyr, bonus);
        }
    }
}