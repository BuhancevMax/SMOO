namespace Task1;

public static class FileManager
{
    public static string GetTextFromFile()
    {
        Console.Write("Введите путь к файлу: ");
        string? input = Console.ReadLine();
        if (input == null) return null;
        if (IsValidFile(input))
        {
            return File.ReadAllText(input);
        }
        return null;
    }
    private static bool IsValidFile(string path)
    {
        
        if (!File.Exists(path))
        {
            Console.WriteLine("Файла не существует!");
            return false;
        }

        if (Path.GetExtension(path).ToLower() != ".txt" && Path.GetExtension(path).ToLower() != ".json")
        {
            Console.WriteLine("Файл не является текстовым!");
            return false;
        }

        try
        {
            using (FileStream stream = File.Open(path, FileMode.Open, FileAccess.Read)) // возможно ли прочитать файл
            {
                return true;
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Ошибка доступа к файлу: {ex.Message}!");
            return false;
        }
    }
}