namespace Task2;

public class TextAnalyzer
{
    public string FilePath { get; }

    public TextAnalyzer(string filePath)
    {
        FilePath = filePath;
    }

    
    public List<WordStat> Analyze() // Метод, який рахує кількість слів
    {
        string text = File.ReadAllText(FilePath);

        var words = text
            .ToLower()
            .Split(new char[] { ' ', '\n', '\r', '\t', ',', '.', '!', '?', ';', ':', '-', '"' },
                StringSplitOptions.RemoveEmptyEntries);

        return words
            .GroupBy(w => w) // Групує всі слова за самими словами (ключ групування — це саме слово)
            .Select(g => new WordStat(g.Key, g.Count())) // Скільки разів зустрілось слово
            .OrderByDescending(ws => ws.Count) // Сортує список за кількістю входжень
            .ToList(); 
    }
    
    public void SaveStats(List<WordStat> stats, string outputFile) // Метод для збереження результату в окремий файл
    {
        using var writer = new StreamWriter(outputFile);
        writer.WriteLine($"Статистика для файлу: {FilePath}");
        foreach (var stat in stats)
        {
            writer.WriteLine($"{stat.Word} : {stat.Count}");
        }
    }
}