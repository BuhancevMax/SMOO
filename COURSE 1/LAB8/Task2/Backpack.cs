namespace Task2;

public class Backpack
{
    public string? Color { get; set; }
    public string? Brand { get; set; }
    public double Weight { get; set; }
    public double Volume { get; set; }
    public static List<Thing>? Content { get; set; }
    
    public Backpack()
    {
        Color = "";
        Brand = "";
        Weight = 0;
        Volume = 0;
        Content = new List<Thing>();
    }
    public Backpack(string color, string brand, double weight, double volume)
    {
        Color = color;
        Brand = brand;
        Weight = weight;
        Volume = volume;
        Content = new List<Thing>();
        Console.WriteLine("Создан рюкзак с объемом: " + Volume);
    }
    
    public void Add(Thing thing)
    {
        double usedVolume = Content.Sum(x => x.Volume); // оставшийся объём (проходимся по каждому элементу "x" в
                                                              // листе Content и суммируем их объём {x.Volume})
                                                              
        if (usedVolume + thing.Volume > Volume)
        {
            double neededVolume = (usedVolume + thing.Volume) - Volume;
            var removedThing = Content.FirstOrDefault(x => x.Volume <= neededVolume);
        
            Console.WriteLine($"Объем превышен! Невозможно добавить предмет: {thing.Name} объём которого - {thing.Volume}, можно убрать: {removedThing?.Name}\n1. Убрать\n2. Оставить");
            string? input = Console.ReadLine();
            bool choice = input == "1" ? true : false;
            if (choice)
            {
                Remove(removedThing);
            }
            else
            {
                return;
            }
        }
        
        Content.Add(thing);
        ThingAdded?.Invoke(thing);
    }
    public void Remove(Thing thing)
    {
        Content?.Remove(thing);
    }
    public delegate void ThingAddedHandler(Thing thing);
    public event ThingAddedHandler? ThingAdded;

    public void ThingAddInfo(Thing thing)
    {
        Console.WriteLine($"Добавлен предмет: {thing.Name}, его объем: {thing.Volume}, оставшийся объём: {Volume - Content.Sum(x => x.Volume)}");
    }
}