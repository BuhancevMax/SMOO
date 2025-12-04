using System.Text;

namespace Task3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            int[] correct = new int[]{1, 50, 2, 11,30, 1, 1};
            string[] answers = new string[7];
            answers[0] = "Професор ліг спати о 8 годині, а встав о 9 годині. Скільки годин проспав професор?";
            answers[1] = "На двох руках десять пальців. Скільки пальців на 10?";
            answers[2] = "Скільки цифр у дюжині?";
            answers[3] = "Скільки потрібно зробити розпилів, щоб розпиляти колоду на 12 частин?";
            answers[4] = "Лікар зробив три уколи в інтервалі 30 хвилин. Скільки часу він витратив?";
            answers[5] = "Скільки цифр 9 в інтервалі 1100?";
            answers[6] = "Пастух мав 30 овець. Усі, окрім однієї, розбіглися. Скільки овець лишилося?";
            int count = 0;
            for (int i = 0; i < answers.Length; i++)
            {
                Console.WriteLine(answers[i]);
                int answer = Convert.ToInt32(Console.ReadLine());
                if (answer == correct[i])
                {
                    count++;
                }
            }
            switch (count)
            {
                case 3:
                    Console.WriteLine("Здібності нижче середнього");
                    break;
                case 4:
                    Console.WriteLine("Здібності середні");
                    break;
                case 5:
                    Console.WriteLine("Нормальний");
                    break;
                case 6:
                    Console.WriteLine("Ерудит");
                    break;
                case 7:
                    Console.WriteLine("Геній");
                    break;
                default:
                    Console.WriteLine("Вам треба відпочити!");
                    break;
            }

        }
    }
}
