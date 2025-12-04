using System.Text;
using System.Text.RegularExpressions;

namespace Task2
{
    internal class Program
    {
        public static bool IsValid(string email)
        {

            // @ - вказує на те, що рядок є літеральним
            // ^ - початок рядка
            // [a-zA-Z] – перший символ має бути літерою
            // [a-zA-Z0-9._%+-]* – після першої літери допускаються літери, цифри, крапка, підкреслення, наголос, плюс і мінус
            // @ – обов'язковий символ 
            // [a-zA-Z0-9.-]+ – доменне ім'я може містити літери, цифри, крапку та дефіс
            // \. – обов'язковий символ крапки
            // (com|localhost) – доменне ім'я може закінчуватися на com або localhost
            // $ – кінець рядка

            string pattern = @"^[a-zA-Z][a-zA-Z0-9._!+-]*@[a-zA-Z0-9.-]+\.(com|localhost)$";

            return Regex.IsMatch(email, pattern); // перевірка на відповідність регулярному виразу
        }
      
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Перевірка, чи відповідає вимогам ваш Email: ");
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
