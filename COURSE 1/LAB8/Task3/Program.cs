namespace Task3;
    internal class Program
    {
        public static void RandomizeArray(int[] array)
        {
            Random random = new Random();
            for (int i = 0; i < array.Length; i++)
            {
                array[i] = random.Next(-100, 100);
            }
        }
        public static void PrintArray(int[] array)
        {
            Console.WriteLine($"Массив: {string.Join(", ", array)}");
        }
        public static void MultiplyOn7(int[] array)
        {
            int[] multiplies = Array.FindAll(array, x => x % 7 == 0);
            Console.WriteLine($"Числа, кратные 7:  {string.Join(", ", multiplies)}");
        }
        public static void PositiveNumbers(int[] array)
        {
            int[] positiveArray = Array.FindAll(array, x => x > 0);
            Console.WriteLine($"Позитивные числа: {string.Join(", ", positiveArray)}");
        }
        public static void IsDayOfProgrammer(DateTime day)
        {
            Predicate<DateTime> isProgrammerDay = date => date.DayOfYear == 256;
            string result = isProgrammerDay(day) ? "Да" : "Нет";
            Console.WriteLine($"Дата: {day.ToShortDateString()} - день программиста? - {result}");
        }
        public static void FindWordInString(string Word, string Text)
        {
            Func<string, string, bool> isWordInString = (text, word) => text.Contains(word);
            string result = isWordInString(Text, Word) ? "Да" : "Нет";
            Console.WriteLine($"Слово \"{Word}\" найдено в тексте? - {result}");
        }
        public static void FindWordsInString(string[] Words, string Text)
        {
            bool isWords = false;
            Func<string, string, bool> isWordsInString = (text, word) => text.Contains(word);
            List<string> findWords = new List<string>();
            foreach (var Fword in Words)
            {
                if (isWordsInString(Text, Fword))
                {
                    isWords = true;
                    findWords.Add(Fword);
                }
            }

            if (isWords) Console.WriteLine($"Найденные слова: {string.Join(", ", findWords)}");
            else Console.WriteLine($"Слова \"{string.Join(", ", Words)}\" не найдены в тексте!");
        }
        
        public static void Main()
        {
            int[] array = new int[15];
            RandomizeArray(array);
            PrintArray(array);
            
            // Task 1
            MultiplyOn7(array);
            
            // Task 2
            PositiveNumbers(array);
            
            // Task 3
            IsDayOfProgrammer(new DateTime(2025, 9, 13));
            
            // Task 4
            string text = "Бла бла бла абуб биби";
            string[] arrWords = { "бебе","абуб","бибиа" };
            FindWordInString("блу", text);
            FindWordsInString(arrWords, text);
        }
        
    }


