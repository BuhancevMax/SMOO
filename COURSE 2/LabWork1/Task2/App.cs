namespace Task2;

public class App
{
    private string _indexFile;

    public App(string indexFile)
    {
        _indexFile = indexFile;
    }

    public void Run()
    {
        if (!File.Exists(_indexFile))
        {
            Console.WriteLine("Файл firstFile.txt не знайдено!");
            return;
        }

        string[] files = File.ReadAllLines(_indexFile);

        if (files.Length == 0)
        {
            Console.WriteLine("У файлі firstFile.txt немає жодного шляху до текстового файлу.");
            return;
        }

        while (true)
        {
            Console.WriteLine("\nДоступні файли для аналізу:");
            for (int i = 0; i < files.Length; i++)
            {
                Console.WriteLine($"{i + 1}. {files[i]}");
            }

            Console.Write("Оберіть номер файлу (або 0 для виходу): ");
            if (!int.TryParse(Console.ReadLine(), out int choice) || choice < 0 || choice > files.Length)
            {
                Console.WriteLine("Некоректний вибір.");
                continue;
            }

            if (choice == 0) break;

            string selectedFile = files[choice - 1];
            if (!File.Exists(selectedFile))
            {
                Console.WriteLine($"Файл {selectedFile} не знайдено.");
                continue;
            }

            var analyzer = new TextAnalyzer(selectedFile);
            var stats = analyzer.Analyze();

            Console.WriteLine($"\nСтатистика для файлу: {selectedFile}");
            foreach (var stat in stats)
            {
                Console.WriteLine($"{stat.Word} : {stat.Count}");
            }

            Console.Write("Зберегти результат у файл? (y/n): ");
            string saveChoice = Console.ReadLine();
            
            if (saveChoice?.ToLower() == "y")
            {
                string outputFile = $"stats_{Path.GetFileName(selectedFile)}.txt";
                analyzer.SaveStats(stats, outputFile);
                Console.WriteLine($"Результат збережено у файл {outputFile}");
            }
        }
    }
}