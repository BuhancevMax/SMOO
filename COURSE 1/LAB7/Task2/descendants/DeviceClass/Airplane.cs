using Task2.interfaces;

namespace Task2.descendants.DeviceClass;

    public class Airplane : Device, IEngine, IPart
    {
        public string DescriptionOfEngine { get; set; }
        public int EnginePower { get; set; }
        public void Start()
        {
            Console.WriteLine($"The airplane {Name} has started the engine!");
        }
        public string NameOfPart { get; set; }
        public string DescriptionOfPart { get; set; }
        public int PriceOfPart { get; set; }
        public int WeightOfPart { get; set; }
        public override string ToString()
        {
            return $"[Airplane {Name}]\nWeight: {Weight} kg\nEngine power: {EnginePower}\nDescription of engine: {DescriptionOfEngine}\n Is electronic: {IsElectronic}";
        }
        public void GetInfo()
        {
            Console.WriteLine($"NameOfPart: {NameOfPart}\nDescription: {DescriptionOfPart}\nPrice: {PriceOfPart}\nWeight: {WeightOfPart}");
        }
    }


