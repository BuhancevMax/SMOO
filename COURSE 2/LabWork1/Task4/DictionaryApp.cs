namespace Task4;

public class DictionaryApp
    {
        private DictionaryManager dict;

        public DictionaryApp(string type)
        {
            dict = new DictionaryManager(type);
        }

        public void Run()
        {
            while (true)
            {
                Console.WriteLine("\n=== МЕНЮ ===");
                Console.WriteLine("1. Додати слово");
                Console.WriteLine("2. Замінити слово");
                Console.WriteLine("3. Додати переклад");
                Console.WriteLine("4. Замінити переклад");
                Console.WriteLine("5. Видалити слово");
                Console.WriteLine("6. Видалити переклад");
                Console.WriteLine("7. Пошук перекладу");
                Console.WriteLine("8. Вивести словник");
                Console.WriteLine("9. Зберегти у файл");
                Console.WriteLine("10. Завантажити словник з файлу");
                Console.WriteLine("11. Експортувати слово");
                Console.WriteLine("0. Вихід");
                Console.Write("Ваш вибір: ");

                string choice = Console.ReadLine()!;
                switch (choice)
                {
                    case "1":
                        Console.Write("Слово: ");
                        string word = Console.ReadLine()!;
                        Console.Write("Переклади (через кому): ");
                        var trans = Console.ReadLine()!.Split(',').ToList();
                        dict.AddWord(word, trans);
                        break;
                    case "2":
                        Console.Write("Яке слово замінити: ");
                        string oldWord = Console.ReadLine()!;
                        Console.Write("Нове слово: ");
                        string newWord = Console.ReadLine()!;
                        dict.ReplaceWord(oldWord, newWord);
                        break;
                    case "3":
                        Console.Write("Слово: ");
                        string w1 = Console.ReadLine()!;
                        Console.Write("Новий переклад: ");
                        string tr1 = Console.ReadLine()!;
                        dict.AddTranslation(w1, tr1);
                        break;
                    case "4":
                        Console.Write("Слово: ");
                        string w2 = Console.ReadLine()!;
                        Console.Write("Який переклад замінити: ");
                        string oldTr = Console.ReadLine()!;
                        Console.Write("Новий переклад: ");
                        string newTr = Console.ReadLine()!;
                        dict.ReplaceTranslation(w2, oldTr, newTr);
                        break;
                    case "5":
                        Console.Write("Слово: ");
                        dict.RemoveWord(Console.ReadLine()!);
                        break;
                    case "6":
                        Console.Write("Слово: ");
                        string w3 = Console.ReadLine()!;
                        Console.Write("Який переклад видалити: ");
                        string trDel = Console.ReadLine()!;
                        dict.RemoveTranslation(w3, trDel);
                        break;
                    case "7":
                        Console.Write("Слово: ");
                        var res = dict.FindTranslations(Console.ReadLine()!);
                        Console.WriteLine(res.Count > 0 ? string.Join(", ", res) : "Переклади не знайдені");
                        break;
                    case "8":
                        dict.PrintAll();
                        break;
                    case "9":
                        Console.Write("Файл: ");
                        dict.SaveToFile(Console.ReadLine()!);
                        break;
                    case "10":
                        Console.Write("Файл: ");
                        dict = DictionaryManager.LoadFromFile(Console.ReadLine()!);
                        break;
                    case "11":
                        Console.Write("Слово: ");
                        string w4 = Console.ReadLine()!;
                        Console.Write("Файл: ");
                        string f = Console.ReadLine()!;
                        dict.ExportWord(w4, f);
                        break;
                    case "0":
                        return;
                }
            }
        }
    }