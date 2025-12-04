
namespace Task1;

internal class Program
{
    static void Main(string[] args)
    {
        Trip trip1 = new Trip("Dnipro", 591, new DateTime(2022, 03, 15), new[] { "Lviv", "Kharkiv", "Dnipro" });
        Trip trip2 = new Trip("Kyiv", 592, new DateTime(2022, 03, 16),new []{"Dnipro", "Lviv", "Kyiv" });
        Trip trip3 = new Trip("Lviv", 593, new DateTime(2022, 03, 17), new[] { "Kyiv", "Dnipro", "Lviv" });
        
        Trip[] trips = {trip1, trip2, trip3};

        string fileName = "trips.json";
        Trip.WriteToFile(fileName, trips);
        
        Trip[] tripsFromFile = Trip.ReadFromFile(fileName);
        foreach (Trip trip in tripsFromFile)
        {
            Console.WriteLine(trip);
        }
        
        
    }
    
}