namespace Task3;

public class PrinterApp
{
    public void Run()
    {
        var queue = new PrintQueue();

        while (true)
        {
            Console.WriteLine("\nМеню:");
            Console.WriteLine("1. Додати завдання");
            Console.WriteLine("2. Друкувати наступне завдання");
            Console.WriteLine("3. Показати статистику");
            Console.WriteLine("4. Зберегти статистику у файл");
            Console.WriteLine("0. Вихід");
            Console.Write("Ваш вибір: ");

            string choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Введіть ім'я користувача: ");
                    string user = Console.ReadLine();
                    Console.Write("Введіть назву документа: ");
                    string doc = Console.ReadLine();
                    Console.Write("Введіть пріоритет (1–10): ");
                    int.TryParse(Console.ReadLine(), out int priority);
                    queue.AddJob(new PrintJob(user, doc, priority));
                    break;

                case "2":
                    queue.ProcessNextJob();
                    break;

                case "3":
                    queue.ShowLog();
                    break;

                case "4":
                    queue.SaveLogToFile("print_log.txt");
                    break;

                case "0":
                    return;

                default:
                    Console.WriteLine("Некоректний вибір.");
                    break;
            }
        }
    }
}