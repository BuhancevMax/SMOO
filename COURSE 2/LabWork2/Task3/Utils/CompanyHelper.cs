using Task3.Models;

namespace Task3.Utils;

public static class CompanyHelper
{
    public static void PrintTotalEmployeeCount(int count)
    {
        Console.WriteLine($"\n1. Загальна кількість працівників: {count}");
    }

    public static void PrintTotalSalary(decimal totalSalary)
    {
        Console.WriteLine($"\n2. Загальна сума зарплати до виплати: {totalSalary:C}");
    }

    public static void PrintYoungestVeteran(Employer? veteran)
    {
        Console.WriteLine("\n3. Наймолодший працівник з вищою освітою серед 10 з найбільшим стажем:");
        Console.WriteLine(veteran != null ? $"   {veteran}" : "   Дані відсутні.");
    }

    public static void PrintManagerStats((Manager? Youngest, Manager? Oldest) managers)
    {
        Console.WriteLine("\n4. Наймолодший та найстарший менеджери:");
        Console.WriteLine(managers.Youngest != null ? $"   Наймолодший: {managers.Youngest}" : "   Менеджери відсутні.");
        Console.WriteLine(managers.Oldest != null ? $"   Найстарший: {managers.Oldest}" : "   Менеджери відсутні.");
    }

    public static void PrintOctoberBorn(IEnumerable<IGrouping<string, Employer>> groups)
    {
        Console.WriteLine("\n5. Працівники, народжені у жовтні, за посадами:");
        if (!groups.Any())
        {
            Console.WriteLine("   Працівники, народжені у жовтні, відсутні.");
            return;
        }
        foreach (var group in groups)
        {
            Console.WriteLine($"   Посада: {group.Key}");
            foreach (var emp in group)
            {
                Console.WriteLine($"     - {emp.FirstName} {emp.LastName}");
            }
        }
    }

    public static void PrintVolodymyrAnalysis((IEnumerable<Employer> AllVolodymyrs, Employer? Youngest, decimal? Bonus) analysisResult)
    {
        Console.WriteLine("\n6. Аналіз працівників з іменем 'Володимир':");
        if (!analysisResult.AllVolodymyrs.Any())
        {
            Console.WriteLine("   Працівники з іменем Володимир відсутні.");
            return;
        }
        
        Console.WriteLine("   Усі Володимири на підприємстві:");
        foreach (var volodymyr in analysisResult.AllVolodymyrs)
        {
            Console.WriteLine($"     - {volodymyr}");
        }

        Console.WriteLine(analysisResult.Youngest != null
            ? $"   Наймолодшому ({analysisResult.Youngest.FirstName} {analysisResult.Youngest.LastName}) нараховано премію: {analysisResult.Bonus:C}"
            : "");
    }
}