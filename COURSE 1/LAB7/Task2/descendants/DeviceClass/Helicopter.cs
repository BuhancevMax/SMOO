using Task2.interfaces;

namespace Task2.descendants.DeviceClass;

    public class Helicopter : Device, IEngine, IPart
    {
        public string DescriptionOfEngine { get; set; }
        public int EnginePower { get; set; }
        
        public Helicopter(string? name, double weight, int enginePower)
        {
            Name = name;
            Weight = weight;
            EnginePower = enginePower;
        }
        
        public void Start()
        {
            Console.WriteLine($"The helicopter {Name} has started the engine!");
        }
        public override string ToString()
        {
            return $"[Helicopter {Name}]\nWeight: {Weight} kg\nEngine power: {EnginePower}\nDescription of engine: {DescriptionOfEngine}\n Is electronic: {IsElectronic}";
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


