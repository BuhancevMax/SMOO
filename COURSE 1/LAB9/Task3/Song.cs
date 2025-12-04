
namespace Task3;

public class Song
{
    public string Title { get; set; }
    public string Author { get; set; }
    public int Year { get; set; }
    public string Composer { get; set; }
    public string Lyrics { get; set; }
    public string[] Performers { get; set; }
    
    public Song(string title, string author, int year, string composer, string lyrics, string[] performers)
    {
        Title = title;
        Author = author;
        Year = year;
        Composer = composer;
        Lyrics = lyrics;
        Performers = performers;
    }
    public Song()
    {
        Title = "";
        Author = "";
        Year = 0;
        Composer = "";
        Lyrics = "";
        Performers = Array.Empty<string>();
    }

    public static string GetSongTextFromFile(string path)
    {
        if (string.IsNullOrWhiteSpace(path)) throw new ArgumentException("Путь к файлу не может быть пустым!");
        
        if (!IsValidFile(path)) throw new ArgumentException("Файл не прошел проверку!");
        
        return File.ReadAllText(path);
        
    }
    public override string ToString()
    {
        return $"Название песни: {Title}\nАвтор: {Author}\nГод написания: {Year}\nКомпозитор: {Composer}\nСписок исполнителей: {string.Join(", ", Performers)}";
    }
    
    private static bool IsValidFile(string path)
    {
        
        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не найден!");
            return false;
        }

        if (Path.GetExtension(path).ToLower() != ".txt" && Path.GetExtension(path).ToLower() != ".json")
        {
            Console.WriteLine("Файл не является текстовым!");
            return false;
        }

        try
        {
            using var stream = File.OpenRead(path); // возможно ли прочитать файл 
            return true;
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка: {ex.Message}");
            return false;
        }
    }
}