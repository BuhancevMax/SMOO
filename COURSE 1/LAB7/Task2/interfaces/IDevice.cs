namespace Task2.interfaces;

public interface IDevice
{
    string Name { get; set; }
    int Height { get; set; }
    int Size { get; set; }
    bool HaveEngine { get; set; }
    void GetInfo();
}