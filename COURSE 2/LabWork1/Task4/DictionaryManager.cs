namespace Task4;

public class DictionaryManager
{
    public string Type { get; }
    private List<WordEntry> words = new();

    public DictionaryManager(string type)
    {
        Type = type;
    }
    
    public void AddWord(string word, List<string> translations)
        {
            if (words.Any(w => w.Word == word))
            {
                Console.WriteLine("Таке слово вже існує!");
                return;
            }
            words.Add(new WordEntry(word, translations));
        }

        // Замінити слово
        public void ReplaceWord(string oldWord, string newWord)
        {
            var entry = words.FirstOrDefault(w => w.Word == oldWord);
            if (entry != null)
            {
                entry = new WordEntry(newWord, entry.Translations);
                words.RemoveAll(w => w.Word == oldWord);
                words.Add(entry);
            }
        }

        // Додати переклад
        public void AddTranslation(string word, string translation)
        {
            var entry = words.FirstOrDefault(w => w.Word == word);
            if (entry != null && !entry.Translations.Contains(translation))
            {
                entry.Translations.Add(translation);
            }
        }

        // Замінити переклад
        public void ReplaceTranslation(string word, string oldTranslation, string newTranslation)
        {
            var entry = words.FirstOrDefault(w => w.Word == word);
            if (entry != null && entry.Translations.Contains(oldTranslation))
            {
                int index = entry.Translations.IndexOf(oldTranslation);
                entry.Translations[index] = newTranslation;
            }
        }

        // Видалити переклад
        public void RemoveTranslation(string word, string translation)
        {
            var entry = words.FirstOrDefault(w => w.Word == word);
            if (entry != null && entry.Translations.Count > 1)
            {
                entry.Translations.Remove(translation);
            }
            else
            {
                Console.WriteLine("Не можна видалити останній переклад!");
            }
        }

        // Видалити слово
        public void RemoveWord(string word)
        {
            words.RemoveAll(w => w.Word == word);
        }

        // Пошук перекладу
        public List<string> FindTranslations(string word)
        {
            var entry = words.FirstOrDefault(w => w.Word == word);
            return entry?.Translations ?? new List<string>();
        }

        // Збереження словника у файл
        public void SaveToFile(string fileName)
        {
            using var writer = new StreamWriter(fileName);
            writer.WriteLine(Type);
            foreach (var entry in words)
            {
                writer.WriteLine($"{entry.Word}:{string.Join(",", entry.Translations)}");
            }
        }

        // Завантаження словника
        public static DictionaryManager LoadFromFile(string fileName)
        {
            if (!File.Exists(fileName))
                throw new FileNotFoundException("Файл словника не знайдено!");

            var lines = File.ReadAllLines(fileName);
            var dict = new DictionaryManager(lines[0]);
            foreach (var line in lines.Skip(1))
            {
                var parts = line.Split(':');
                var word = parts[0];
                var translations = parts[1].Split(',').ToList();
                dict.AddWord(word, translations);
            }
            return dict;
        }

        // Експорт слова у файл
        public void ExportWord(string word, string fileName)
        {
            var entry = words.FirstOrDefault(w => w.Word == word);
            if (entry != null)
            {
                using var writer = new StreamWriter(fileName);
                writer.WriteLine($"{entry.Word} -> {string.Join(", ", entry.Translations)}");
            }
        }

        // Вивід словника
        public void PrintAll()
        {
            Console.WriteLine($"Словник ({Type}):");
            foreach (var entry in words)
            {
                Console.WriteLine($"{entry.Word} -> {string.Join(", ", entry.Translations)}");
            }
        }
    }