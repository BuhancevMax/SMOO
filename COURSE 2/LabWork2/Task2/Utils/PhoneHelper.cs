namespace Task2.Utils;

public static class PhoneHelper
{
    public static void DisplayAllPhoneTasks(IPhoneQueryService phoneService)
    {
        Console.WriteLine($"Загальна кількість телефонів: {phoneService.GetTotalCount()}");
        Console.WriteLine($"Мінімальна ціна: {phoneService.GetMinPrice()}");
        Console.WriteLine($"Максимальна ціна: {phoneService.GetMaxPrice()}");
        Console.WriteLine($"Середня ціна: {phoneService.GetAveragePrice():C}");
        
        Console.WriteLine();
        
        Console.WriteLine($"Виробник з найбільшою кількістю моделей: {phoneService.GetManufacturerWithMostPhones()}");
        Console.WriteLine($"Найдешевший телефон: {phoneService.GetCheapestPhoneInfo()}");
        
        Console.WriteLine("\n--- Групування за виробником ---");
        var groupsByManuf = phoneService.GroupByManufacturer();
        foreach (var group in groupsByManuf)
        {
            Console.WriteLine($"  -> {group.Key} ({group.Count()} моделей):");
            foreach (var phone in group)
            {
                Console.WriteLine($"    - {phone.ModelName} ({phone.Price})");
            }
        }
        
        Console.WriteLine("\n--- Групування за роком випуску ---");
        var groupsByYear = phoneService.GroupByYear();
        foreach (var group in groupsByYear)
        {
            Console.WriteLine($"  -> Рік {group.Key} ({group.Count()} моделей):");
            foreach (var phone in group)
            {
                Console.WriteLine($"    - {phone.Manufacturer} {phone.ModelName}");
            }
        }
    }
}