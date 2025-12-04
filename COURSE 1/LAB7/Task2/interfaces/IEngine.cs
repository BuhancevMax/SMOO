namespace Task2.interfaces;

public interface IEngine
{
    string DescriptionOfEngine { get; set; }
    int EnginePower { get; set; }
    public void Start();
}