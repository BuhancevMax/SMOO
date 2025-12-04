namespace Task1.Utils;

public class QueryHelper
{
    public static void DisplayResults(string title, IEnumerable<Company> companies)
    {
        Console.WriteLine();
        Console.WriteLine($"{title} ({companies.Count()} фірм):");

        if (companies.Any())
        {
            foreach (var company in companies)
            {
                Console.WriteLine(company);
            }
        }
        else
        {
            Console.WriteLine("Результатів не знайдено.");
        }
    }
}