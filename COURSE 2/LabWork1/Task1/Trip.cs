namespace Task2;

public class Trip
{
    public string Destination { get; set; } // пункт слідування
    public int TrainNumber { get; set; } // номер поїзда
    public DateTime DepartureTime { get; set; } // час відправлення
    public List<string> Stops { get; set; } // список зупинок

    public Trip(string destination, int trainNumber, DateTime departureTime, List<string> stops)
    {
        Destination = destination;
        TrainNumber = trainNumber;
        DepartureTime = departureTime;
        Stops = stops;
    }

    public override string ToString()
    {
        return $"Поїзд №{TrainNumber} -> {Destination}, Відправлення: {DepartureTime:HH:mm}, Зупинки: {string.Join(", ", Stops)}";
    }
}