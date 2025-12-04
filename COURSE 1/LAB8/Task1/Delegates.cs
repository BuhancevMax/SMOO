namespace Task1;

public class Delegates
{
    public static void ShowTime()
    {
        Console.WriteLine("Time: " + DateTime.Now.ToString("HH:mm:ss"));
    }

    public static void ShowDate()
    {
        Console.WriteLine("Date: " + DateTime.Now.ToString("dd.MM.yyyy"));
    }

    public static void ShowDayOfWeek()
    {
        Console.WriteLine("Day of week: " + DateTime.Now.DayOfWeek);
    }
    public static bool IsPrime(int number)
    {
        for (int i = 2; i < number; i++)
        {
            if (number % i == 0)
            {
                Console.WriteLine($"{number} is not prime");
                return false;
            }
        }

        Console.WriteLine($"{number} is prime");
        return true;
    }
    private static bool IsPerfectSquare(int x)
    {
        int s = (int)Math.Sqrt(x);
        return s * s == x;
    }

    private static bool CalculateFibonacci(int n)
    {
        
        return IsPerfectSquare(5 * n * n + 4) || IsPerfectSquare(5 * n * n - 4);
    }

    public static bool IsFibonacci(int number)
    {
        if (CalculateFibonacci(number))
        {
            Console.WriteLine($"{number} is Fibonacci");
            return true;
        }else {
            Console.WriteLine($"{number} is not Fibonacci");
            return false;
        }
    }

    public static int SquareOfTriangle(int baseNumber, int heightNumber)
    {
        int square = (int)(0.5 * baseNumber * heightNumber);
        Console.Write($"Square of triangle: ");
        return square;
    }

    public static int SquareOfRectangle(int a, int b)
    {
        int square = a * b;
        Console.Write($"Square of rectangle: ");
        return square;
    }
    
}