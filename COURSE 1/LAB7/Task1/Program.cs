namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Console.WriteLine("=======Створити один об’єкт типу Catalog, вивести скорочену інформацію про директорію на екран (метод ToShortString())========");
            Catalog catalog = new Catalog("Каталог №1", "Test", 10, KindOf.SystemPrograms);   
            Console.WriteLine(catalog.ToShortString());

            Console.WriteLine("===============Виведенная значень індексатора=============");
            catalog.PrintIndexerOfCatalog();
            
            Console.WriteLine("===============Присвоєння значень, та вивід на екран=============");
            catalog.CatalogName = "Документы";
            catalog.Description = "Личные документы пользователя";
            catalog.SizeOfCatalog = 15;
            catalog.KindOfCatalog = KindOf.Documents;
            Console.WriteLine(catalog);

            Console.WriteLine("=========================Додавання файлів за допомогою метода, та вивід на екран=====================");
            catalog.CreateFile("доклад.doc", new Person("Макс"),new DateTime(2025,2,12));
            catalog.CreateFile("report.pdf", new Person("Маша"), new DateTime(2025, 3, 29));
            catalog.CreateFile("лабораторная работа.cpp", new Person("Юра"), new DateTime(2025, 5, 4));
            catalog.CreateFile("мой кот.png", new Person("Юля"), new DateTime(2022, 8, 22));
            Console.WriteLine(catalog);

            Console.WriteLine("===================================Відсортування файлів=================================\nВідсортований каталог:");
            Array.Sort(catalog.Files);
            Console.WriteLine(catalog);
            catalog.Save("output.txt");
            
            File[] subset = catalog.Files.Take(2).ToArray(); // берет первые два файла и конвертирует в отдельный массив
            Catalog newCatalog = new Catalog("Каталог 2", "Скопійовані файли", 0, KindOf.Documents, subset);
            newCatalog.Save("subset.txt");
            Console.WriteLine(newCatalog);
        }
    }
}
