namespace Task2
{
    internal class Program
    {
        private static void Main()
        {
            Backpack backpack = new Backpack("Blue", "Nike", 10, 100);
            backpack.ThingAdded += backpack.ThingAddInfo;
            
                backpack.Add(new Thing("NoteBook", 40));
                backpack.Add(new Thing("Shoes", 20));
                backpack.Add(new Thing("Shirt", 10));
                backpack.Add(new Thing("Ukulele", 30));
                backpack.Add(new Thing("Headset", 20));
                
        }
    }
}

