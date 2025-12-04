namespace Task2;

public class Class1
{
    static void Main()
    {
        List<Trip> trips = new List<Trip>()
        {
            new Trip("Київ", 101, new DateTime(2025, 9, 24, 9, 30, 0), new List<string>{ "Полтава", "Миргород", "Лубни" }),
            new Trip("Львів", 102, new DateTime(2025, 9, 24, 11, 15, 0), new List<string>{ "Рівне", "Тернопіль", "Харків" }),
            new Trip("Одеса", 103, new DateTime(2025, 9, 24, 14, 45, 0), new List<string>{ "Умань", "Кременчук" })
        };
        
        trips.Add(new Trip("Харків", 404, new DateTime(2025, 9, 24, 16, 0, 0), new List<string>{ "Полтава", "Красноград" }));
        
        var trainToEdit = trips.FirstOrDefault(t => t.TrainNumber == 102); // змінюємо пункт призначення у поїзда №102
        if (trainToEdit != null)
        {
            trainToEdit.Destination = "Ужгород";
        }
        
        trips.RemoveAll(t => t.TrainNumber == 103); // видалення поїзда за номером
        
        string searchStation = "Полтава";
        var result = trips.Where(t => t.Stops.Contains(searchStation)); // знаходимо всі поїзди, які зупиняються на станції "Полтава"
        
        Console.WriteLine($"Поїзди, які зупиняються на станції {searchStation}:"); 
        foreach (var trip in result)
        {
            Console.WriteLine($"Поїзд №{trip.TrainNumber} -> {trip.Destination}");
        }
        
        string filePath = "trips_result.txt"; // зберігаємо у файл
        using (StreamWriter writer = new StreamWriter(filePath))
        {
            writer.WriteLine($"Поїзди, які зупиняються на станції {searchStation}:");
            foreach (var trip in result)
            {
                writer.WriteLine($"Поїзд №{trip.TrainNumber} -> {trip.Destination}");
            }
        }
        
    }
}