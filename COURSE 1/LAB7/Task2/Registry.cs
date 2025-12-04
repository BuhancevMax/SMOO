using Task2.interfaces;

namespace Task2;

public class Registry 
{
    public Device[] devices;

    public void PrintAllDevices()
    {
        foreach (var device in devices)
        {
            Console.WriteLine(device);
        }
    }

    public void PrintElectronicDevices()
    {
        foreach (var device in devices)
        {
            if (device.IsElectronic)
            {
                Console.WriteLine(device);
            }
        }
    }

    public void PrintDevicesWithoutEngine()
    {
        foreach (var device in devices)
        {
            if (!device.HaveEngine)
            {
                Console.WriteLine(device);
            }
        }
    }
    
    
    
    
    public Registry(Device[] devices)
    {
        this.devices = devices;
    }
    public Registry()
    {
        devices = new Device[0];
    }
    
}