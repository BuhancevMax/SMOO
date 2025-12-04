using System.Transactions;

namespace Task2
{
    internal class Program
    {
        static double CalculateS(double x)
        {
            double sum = 1, temp = 1, epsilon = 1e-6; 
            int n = 1;
            
            while (true)
            {
                double chiselnik = 1;
                for (int i = 1; i <= 2 * n - 3; i += 2)
                {
                    chiselnik *= i;
                }
                double znamennik = Factorial(n) * Math.Pow(2, 3 * n);
                temp = Math.Pow(-1, n - 1) * chiselnik / znamennik * Math.Pow(x - 4, n);

                if (Math.Abs(temp) < epsilon)
                    break;

                sum += temp;
                n++;
            }

            return sum;
        }
        static double Factorial(int n)
        {
            double result = 1;
            for (int i = 1; i <= n; i++)
            {
                result *= i;
            }
            return result;
        }
        static void Main(string[] args)
        {
            double[] x = new double[] {2,1,0};
            foreach (double num in x)
            {
                double sum = CalculateS(num);
                double y = 0.5 * Math.Sqrt(num);
                Console.WriteLine($"x = {num}: Сума ряду S(x) = {sum:F6}, y(x) = {y:F6}");
            }
        }
    }
}
