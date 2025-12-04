using System;

namespace LabWork1
{
    internal class Program
    {
        static void Main(string[] args)
        { // Лабороторна робота 1; Варіант 4
            double result;
            Console.WriteLine("Введіть x: ");
            double x = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введіть y: ");
            double y = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Введіть z: ");
            double z = Convert.ToDouble(Console.ReadLine());

            result = Math.Pow(Math.Abs(Math.Cos(x) - Math.Cos(y)),1+2*Math.Pow(Math.Sin(y),2)) *
                (1 + z + (Math.Pow(z,2)/2)) + (Math.Pow(z,3)/3) + (Math.Pow(z,4)/4);
            Console.WriteLine($"Результат: {result:F4}");

        }
    }
}
