using System.Text.Json;
using Task3.interfaces;

namespace Task3;

public class SongCollection : IVerifyInput
{
    private List<Song> Songs { get; set; } = new();
    public void RunMenu()
    {
        while (true)
        {
            Console.WriteLine("1. Добавить песню\n2. Удалить песню\n3. Изменить песню\n4. Найти песню по названию\n" +
                              "5. Найти песню по исполнителю\n6. Сохранить в файл\n7. Загрузить из файла\n8. Показать все песни\n" +
                              "9. Вывести текст песни\n0. Выход");
            int switchInput = VerifyIntInput(Console.ReadLine()); 
            switch (switchInput)
            {
                case 1:
                    AddSong();
                    break;
                case 2:
                    RemoveSong();
                    break;
                case 3:
                    EditSong();
                    break;
                case 4:
                    if (IsEmpty()) break;
                    Console.Write("Введите название: ");
                    FindSongByTitle(VerifyStringInput(Console.ReadLine()));
                    break;
                case 5:
                    if (IsEmpty()) break;
                    Console.Write("Введите автора: ");
                    FindSongByAuthor(VerifyStringInput(Console.ReadLine()));
                    break;
                case 6:
                    if (IsEmpty()) break;
                    Console.Write("Введите название файла: ");
                    SaveToFile(VerifyStringInput(Console.ReadLine()));
                    break;
                case 7:
                    Console.Write("Введите путь к файлу: ");
                    LoadFromFile(VerifyStringInput(Console.ReadLine()));
                    break;
                case 8:
                    PrintSongs();
                    break;
                case 9:
                    ShowLyrics();
                    break;
                case 0:
                    return;
                default:
                    Console.WriteLine("Неверный выбор!");
                    break;
            }
        }
    }
    public void AddSong()
    {
        Song newSong = new Song();
        Console.WriteLine("Название песни: ");
        newSong.Title = VerifyStringInput(Console.ReadLine());
        Console.WriteLine("Автор песни: ");
        newSong.Author = VerifyStringInput(Console.ReadLine());
        Console.WriteLine("Год написания: ");
        newSong.Year = VerifyIntInput(Console.ReadLine());
        Console.WriteLine("Композитор: ");
        newSong.Composer = VerifyStringInput(Console.ReadLine());
        Console.WriteLine("Путь к файлу с текстом песни: ");
        newSong.Lyrics = Song.GetSongTextFromFile(VerifyStringInput(Console.ReadLine()));
        Console.WriteLine("Исполнители: ");
        newSong.Performers = VerifyStringInput(Console.ReadLine()).Split(new[] { ' ', ',', '\n' }, StringSplitOptions.RemoveEmptyEntries);
        Songs?.Add(newSong);
        Console.WriteLine("Песня успешно добавлена в список песен!");
    }
    public void RemoveSong()
    {
        
        if (IsEmpty()) return;
        
        Console.WriteLine("Какую песню вы хотите удалить?");
        PrintSongs();
        
        int index = VerifyIntInput(Console.ReadLine());
        
        if (index > Songs?.Count || index < 0)
        {
            Console.WriteLine("Песня не найдена!");
            return;
        }
        
        Songs.RemoveAt(index);
        Console.WriteLine("Песня успешно удалена!");
        
    }
    public void PrintSongs()
    {
        if (IsEmpty()) return;
        
        for (int i = 0; i < Songs.Count; i++)
        {
            Console.WriteLine($"{i}: {Songs[i]}");
        }
        
    }
    public void EditSong()
    {
        if (IsEmpty()) return;

        PrintSongs();
        Console.Write("Введите индекс песни которую хотите редактировать: ");
        
        int index = VerifyIntInput(Console.ReadLine());
        
        if (index >= Songs.Count || index < 0)
        {
            Console.WriteLine("Неверный индекс!");
            return;
        }
        
        Song song = Songs[index];
        Console.WriteLine("Что изменить:\n1. Название\n2. Автор\n3. Год написания\n4. Композитор\n5. Текст из файла\n6. Исполнители");
        index = VerifyIntInput(Console.ReadLine());
        switch (index)
        {
            case 1:
                Console.Write("Новое название: ");
                song.Title = VerifyStringInput(Console.ReadLine());
                break;
            case 2:
                Console.Write("Новый автор: ");
                song.Author = VerifyStringInput(Console.ReadLine());
                break;
            case 3:
                Console.Write("Новый год: ");
                song.Year = VerifyIntInput(Console.ReadLine());
                break;
            case 4:
                Console.Write("Новый композитор: ");
                song.Composer = VerifyStringInput(Console.ReadLine());
                break;
            case 5:
                Console.Write("Путь к файлу с текстом песни: ");
                song.Lyrics = Song.GetSongTextFromFile(Console.ReadLine());
                break;
            case 6:
                Console.Write("Введите исполнителей (через запятую): ");
                song.Performers = VerifyStringInput(Console.ReadLine()).Split(',', StringSplitOptions.RemoveEmptyEntries);
                break;
            default:
                Console.WriteLine("Неверный выбор.");
                break;
        }
        Console.WriteLine("Песня обновлена!");
    }
    public void FindSongByTitle(string? title)
    {
        var song = Songs?.Find(s => s.Title == title);
        
        if (song != null)
            Console.WriteLine("Найдена песня:\n" + song);
        else
            Console.WriteLine("Песня не найдена.");
    }
    public void FindSongByAuthor(string? author)
    {
        var song = Songs.Find(s => s.Author == author);
        if (song != null)
            Console.WriteLine("Найдена песня:\n" + song);
        else
            Console.WriteLine("Песня не найдена.");
    }
    public void SaveToFile(string? path)
    {
        string json = JsonSerializer.Serialize(Songs, new JsonSerializerOptions { WriteIndented = true });
        File.WriteAllText(path, json);
        Console.WriteLine("Сохранено в файл: " + path);
    }
    public void LoadFromFile(string? path)
    {
        if (!File.Exists(path))
        {
            Console.WriteLine("Файл не найден.");
            return;
        }
        string json = File.ReadAllText(path);
        Songs = JsonSerializer.Deserialize<List<Song>>(json);
        Console.WriteLine("Загружено из файла: " + path);
    }
    public int VerifyIntInput(string input)
    {
        while (true)
        {
            if (!string.IsNullOrEmpty(input) && int.TryParse(input, out int result) && result >= 0)
                return result;

            Console.Write("Неверно введено число! Введите число заново: ");
            input = Console.ReadLine();
        }
    }
    public string VerifyStringInput(string input)
    {
        while (true)
        {
            if (!string.IsNullOrEmpty(input) && input.Length <= 200)
                return input;

            Console.Write("Неверно введена строка! Введите строку заново: ");
            input = Console.ReadLine();
        }
    }
    public void ShowLyrics()
    {
        if (IsEmpty()) return;

        PrintSongs();
        Console.Write("Введите индекс песни для просмотра текста: ");
        int index = VerifyIntInput(Console.ReadLine());

        if (index >= Songs.Count || index < 0)
        {
            Console.WriteLine("Неверный индекс!");
            return;
        }

        Song song = Songs[index];
        if (!string.IsNullOrEmpty(song.Lyrics))
        {
            Console.WriteLine($"\nТекст песни \"{song.Title}\":\n");
            Console.WriteLine(song.Lyrics);
        }
        else
        {
            Console.WriteLine("У этой песни нет текста.");
        }
    }
    private bool IsEmpty()
    {
        if (Songs == null || Songs.Count == 0)
        {
            Console.WriteLine("В плейлисте нет песен!");
            return true;
        }
        return false;
    }
}