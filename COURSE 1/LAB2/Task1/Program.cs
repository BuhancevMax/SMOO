namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            double[] angles = new double[] { 15, 30, 45, 60 };
            double xStart = 0, xEnd = 0.5, dx = 0.02;
            
            foreach(double angle in angles)
            {
                for (double x = xStart; x < xEnd; x+=dx)
                {
                    double y = x * Math.Tan(angle) - (Math.Pow(x,2) / Math.Pow(Math.Cos(angle), 2));

                    Console.WriteLine($"x = {x:F2}, y = {y:F4}");
                }
            }
        }
    }
}
