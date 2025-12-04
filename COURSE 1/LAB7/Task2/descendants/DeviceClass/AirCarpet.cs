namespace Task2.descendants.DeviceClass;

public class AirCarpet : Device
{
    public string? MagicSource { get; set; }
    public AirCarpet(string? name, double weight, string? magicSource)
    {
        Name = name;
        Weight = weight;
        MagicSource = magicSource;
    }
    public override string ToString()
    {
        return $"[AirCarpet {Name}]\nMagic source: {MagicSource}\nWeight: {Weight} kg\n";
    }
}