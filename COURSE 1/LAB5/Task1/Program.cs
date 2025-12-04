namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Catalog catalog = new Catalog();   
            catalog.CreateCatalog("MyCatalog", "Test", 10, KindOf.UserPrograms, new Person("Макс", "Сидоров"), new DateTime(2025,7,20));
            Console.WriteLine(catalog.ToShortString());

            catalog.PrintIndexerOfCatalog();

            catalog.CreateFile("доклад.doc", new Person("Макс", "Сидоров"),new DateTime(2025,2,12));
            catalog.CreateFile("report.pdf", new Person("Маша", "Рябченко"), new DateTime(2025, 3, 29));

            catalog.CatalogName = "Документы";
            catalog.Description = "Личные документы пользователя";
            catalog.SizeOfCatalog = 15;
            catalog.KindOfCatalog = KindOf.Documents;
            Console.WriteLine(catalog.ToString() + "\n");
            
            Catalog[] disk = {
            catalog, new Catalog("MyCatalog2", "Test2", 20, KindOf.UserPrograms, new File[]{new File("picture.png",new Person("Макс", "Сидоров"), new DateTime(2024, 9, 18))}),
            new Catalog("MyCatalog3", "Test3", 30, KindOf.SystemPrograms, new File[]{new File("system32.exe",new Person ("Жора","Коваль"), new DateTime(2025, 1, 15))})
            };

            foreach (var catalogs in disk)
            {
                if (catalogs.Files.Length >= 2)
                {
                    Console.WriteLine(catalogs.ToShortString());
                    Console.WriteLine();
                }
            }
        }
    }
}
