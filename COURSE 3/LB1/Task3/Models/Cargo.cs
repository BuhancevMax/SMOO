using Task3.Models.Enums;

namespace Task3.Models;

public class Cargo
{
    public CargoType Type { get; }
    public double Weight { get; }

    public Cargo(CargoType type, double weight)
    {
        if(weight <= 0) throw new ArgumentOutOfRangeException(nameof(weight), "Вантаж не може важити менше або 0.");
        Weight = weight;
        Type = type;
    }
}