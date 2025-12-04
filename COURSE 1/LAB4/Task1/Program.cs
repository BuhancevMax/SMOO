using System.Text.RegularExpressions;
using System;
using System.Text;

namespace Task1
{
    internal class Program
    {
        public static bool IsValid(string url)
        {
            
            // @ - вказує на те, що рядок є літеральним
            // ^ - початок рядка
            // (http:\/\/|https:\/\/) - перевірка на наявність http:// або https://
            // ([a-zA-Z0-9]+(\.[a-zA-Z0-9]+)+) - перевірка на наявність домену
            // $ - кінець рядка
            // [a-zA-Z0-9] - букви та цифри
            // + - один або більше разів

            string pattern = @"^(http:\/\/|https:\/\/)([a-zA-Z0-9]+(\.[a-zA-Z0-9]+)+)$"; // регулярний вираз (паттерн)

            return Regex.IsMatch(url, pattern); // перевірка на відповідність регулярному виразу
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Перевірка, чи відповідає вимогам ваш URL: ");
            string url = Console.ReadLine();
            if (IsValid(url))
            {
                Console.WriteLine("Так, відповідає!");
            }
            else
            {
                Console.WriteLine("Ні, не відповідає!");
            }
        }
    }
}
