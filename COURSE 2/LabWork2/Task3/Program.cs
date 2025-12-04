using Task3;
using Task3.Models;
using Task3.Utils;

    class Program
    {
        public static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            var company = new Company("IT-Future");
            company.HireEmployer(new President { FirstName = "Іван", LastName = "Петренко", DateOfBirth = new DateTime(1975, 5, 20), HireDate = new DateTime(2005, 1, 15), Salary = 150000, HasHigherEducation = true });
            company.HireEmployer(new Manager { FirstName = "Марія", LastName = "Сидоренко", DateOfBirth = new DateTime(1988, 10, 3), HireDate = new DateTime(2010, 6, 1), Salary = 80000, HasHigherEducation = true });
            company.HireEmployer(new Manager { FirstName = "Олег", LastName = "Іванов", DateOfBirth = new DateTime(1982, 3, 12), HireDate = new DateTime(2008, 9, 20), Salary = 82000, HasHigherEducation = true });
            company.HireEmployer(new Worker { FirstName = "Андрій", LastName = "Ковальчук", DateOfBirth = new DateTime(1995, 8, 25), HireDate = new DateTime(2018, 2, 10), Salary = 45000, HasHigherEducation = true });
            company.HireEmployer(new Worker { FirstName = "Олена", LastName = "Бондаренко", DateOfBirth = new DateTime(2000, 10, 15), HireDate = new DateTime(2022, 7, 1), Salary = 38000, HasHigherEducation = false });
            company.HireEmployer(new Worker { FirstName = "Володимир", LastName = "Шевченко", DateOfBirth = new DateTime(1992, 11, 30), HireDate = new DateTime(2015, 4, 22), Salary = 52000, HasHigherEducation = true });
            company.HireEmployer(new Worker { FirstName = "Володимир", LastName = "Мельник", DateOfBirth = new DateTime(1998, 1, 10), HireDate = new DateTime(2021, 8, 1), Salary = 40000, HasHigherEducation = false });
            for (int i = 0; i < 8; i++)
            {
                company.HireEmployer(new Worker { FirstName = $"Робітник{i}", LastName = "Прізвище", DateOfBirth = new DateTime(1990 + i, 5, 1), HireDate = new DateTime(2012 + i, 1, 1), Salary = 35000 + i * 1000, HasHigherEducation = i % 2 == 0 });
            }
            
            var analytics = new CompanyService(company.Employers);
            
            CompanyHelper.PrintTotalEmployeeCount(analytics.GetTotalEmployeeCount());
            
            CompanyHelper.PrintTotalSalary(analytics.GetTotalSalaryPayout());
            
            CompanyHelper.PrintYoungestVeteran(analytics.GetYoungestEducatedVeteran());
            
            CompanyHelper.PrintManagerStats(analytics.GetYoungestAndOldestManagers());
            
            CompanyHelper.PrintOctoberBorn(analytics.GetEmployeesBornInOctober());
            
            CompanyHelper.PrintVolodymyrAnalysis(analytics.AnalyzeVolodymyrs());
        }
    }
