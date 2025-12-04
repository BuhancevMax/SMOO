namespace Task2;

public class Thing
{
    public string? Name { get; set; }
    public double Volume { get; set; }
    
    public Thing(string name, double volume)
    {
        Name = name;
        Volume = volume;
    }
}