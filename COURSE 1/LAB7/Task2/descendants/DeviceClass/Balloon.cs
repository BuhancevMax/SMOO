using Task2.interfaces;

namespace Task2.descendants.DeviceClass;

    public class Balloon : Device, IPart
    {
        public double GasVolume { get; set; }
        
        public Balloon(string name, double weight, double gasVolume)
        {
            Name = name;
            Weight = weight;
            GasVolume = gasVolume;
        }
        public override string ToString()
        {
            return $"[Balloon {Name}]\nWeight: {Weight} kg\nGas volume: {GasVolume} m^3";
        }

        public string NameOfPart { get; set; }
        public string DescriptionOfPart { get; set; }
        public int PriceOfPart { get; set; }
        public int WeightOfPart { get; set; }
        
        public void GetInfo()
        {
            Console.WriteLine($"NameOfPart: {NameOfPart}\nDescription: {DescriptionOfPart}\nPrice: {PriceOfPart}\nWeight: {WeightOfPart}");
        }
    }


