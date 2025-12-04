using System.Text.Json;

namespace Task1;
[Serializable]
public class Trip
{
    public string Destination { get; set; }
    public int TrainNumber { get; set; }
    public DateTime DepartureTime { get; set; }
    public string[] Stations { get; set; }
    
    public Trip(string destination, int trainNumber, DateTime departureTime, string[] stations)
    {
        Destination = destination;
        TrainNumber = trainNumber;
        DepartureTime = departureTime;
        Stations = stations;
    }
    public static void WriteToFile(string fileName, Trip[] trips)
    {
        string json = JsonSerializer.Serialize(trips, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(fileName, json);
        Console.WriteLine("Файл успешно сохранён");
    }
    public static Trip[] ReadFromFile(string fileName)
    {
        if (!File.Exists(fileName))
        {
            Console.WriteLine("Файл не найден");
            return Array.Empty<Trip>();
        }
        
        string json = File.ReadAllText(fileName);
        Trip[] trips = JsonSerializer.Deserialize<Trip[]>(json);
        Console.WriteLine("Файл успешно загружен");
        return trips;
    }

    public static void FindTripsByStation(Trip[] trips, string station)
    {
        bool found = false;

        foreach (var trip in trips)
        {
            for (int i = 0; i < trip.Stations.Length; i++)
            {
                if (trip.Stations[i].ToLower() == station.ToLower())
                {
                    Console.WriteLine($"Поезд №{trip.TrainNumber}, пункт назначения: {trip.Destination}");
                    found = true;
                    break;
                }
            }
        }
        if (!found)
        {
            Console.WriteLine("Ни одна поездка не останавливается на этой станции.");
        }
    }


    public override string ToString()
    {
        return $"Поезд под номером: \"{TrainNumber}\" отправляется {DepartureTime.ToShortDateString()}\n" +
               $"на станцию {Destination}, проходя через - {string.Join(", ", Stations)}\n";
    }
}