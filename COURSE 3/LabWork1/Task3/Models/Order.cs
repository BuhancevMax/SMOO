namespace Task3.Models;

public class Order : Entity
{
    public string Destination { get; }
    public double Distance { get; }
    public Cargo Cargo { get; }

    public Order(int id, string destination, double distance, Cargo cargo): base(id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(destination);
        if (distance <= 0) throw new ArgumentOutOfRangeException(nameof(distance), "Дистанція не може бути менше нуля.");
        if (cargo ==  null) throw new ArgumentNullException(nameof(cargo), "Вантаж не може бути порожнім");
        Destination = destination;
        Distance = distance;
        Cargo = cargo;
    }
}