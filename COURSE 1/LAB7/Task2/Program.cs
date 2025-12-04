using Task2.descendants.DeviceClass;

namespace Task2
{
    internal class Program
    {
        public static void Main(string[] args)
        {
            AirCarpet airCarpet = new AirCarpet("Airplane carpet",5,"Jeen's lamp");
            Balloon balloon = new Balloon("Watermelon", 500, 1000);
            
            Registry registry = new Registry();
            registry.devices = new Device[] {airCarpet, balloon};
            registry.PrintAllDevices();
        }
    }
}