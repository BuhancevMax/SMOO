namespace Task2.Models;

public record Phone(string ModelName, string Manufacturer, decimal Price, DateTime ReleaseDate)
{
    public int ReleaseYear => ReleaseDate.Year;

    public override string ToString()
    {
        return $"{Manufacturer} {ModelName} | {ReleaseYear} | Цена: {Price:C}";
    }
}