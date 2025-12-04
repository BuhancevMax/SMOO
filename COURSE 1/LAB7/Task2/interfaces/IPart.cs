namespace Task2.interfaces;

public interface IPart
{
    string NameOfPart { get; set; }
    string DescriptionOfPart { get; set; }
    int PriceOfPart { get; set; }
    int WeightOfPart { get; set; }
    void GetInfo();
}