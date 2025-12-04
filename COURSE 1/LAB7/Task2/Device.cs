namespace Task2
{
    public class Device: IComparable<Device>, IComparer<Device>, ICloneable
    {
        public string? Name{get; set;}
        public double Weight{get; set;} // вес
        public int Size{get; set;} // размеры
        public bool HaveEngine{get; set;}
        public bool IsElectronic { get; set; }
        
        public Device(string? name,double weight, int size, bool haveEngine, bool isElectronic)
        {
            Name = name;
            Weight = weight;
            Size = size;
            HaveEngine = haveEngine;
            IsElectronic = isElectronic;
        }
        public Device()
        {
            Name = "";
            Weight = 0;
            Size = 0;
            HaveEngine = false;
            IsElectronic = false;
        }

        public int CompareTo(Device? other)
        {
            if (other == null) return 1;
            return Weight.CompareTo(other.Weight);
        }

        public int Compare(Device? x, Device? y)
        {
            return string.Compare(x?.Name, y?.Name, StringComparison.Ordinal);
        }
        
        public object Clone()
        {
            return new Device(Name, Weight, Size, HaveEngine, IsElectronic);
        }

        override public string ToString()
        {
            return $"Наименование техники: {Name}\nРазмер (кв.м.): {Size}\nВес: {Weight}\nПрисутствие двигателя: {HaveEngine}";
        }
        
    }
}

