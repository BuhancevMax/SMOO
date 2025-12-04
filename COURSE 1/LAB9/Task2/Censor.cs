namespace Task2;

public static class Censor
{
    public static void Run()
    {
        Console.Write("Введите путь к текстовому файлу: ");
        string? textPath = Console.ReadLine();

        Console.Write("Введите путь к файлу со словами для цензуры: ");
        string? banListPath = Console.ReadLine();

        if (!File.Exists(textPath) || !File.Exists(banListPath))
        {
            Console.WriteLine("Один из файлов не найдено");
            return;
        }

        string text = File.ReadAllText(textPath);
        string[] bannedWords = File.ReadAllText(banListPath)
            .Split(new[] { ' ', ',', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries);

        foreach (var word in bannedWords)
        {
            string mask = new string('*', word.Length);
            text = text.Replace(word, mask);
        }

        File.WriteAllText("censored_output.txt", text);
        Console.WriteLine("Цензурованный текст сохранено в файл: censored_output.txt");
    }
}