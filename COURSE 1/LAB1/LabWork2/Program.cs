namespace Task2
{
    internal class Program
    {
        public static void Calculation(double xMax, double xMin, byte repeat, StreamWriter writer)
        {
            double step = (xMax - xMin) / repeat;
            for (double x = xMin; x <= xMax; x += step)
            {
                double result = (4 * x) + (1) / (x + 1);
                writer.WriteLine($"Для заданої функції Y({x,4:F2})= {result,-7:F4}");
            }
        }
        static void Main(string[] args)
        {
            byte repeats = 8;
            string[] lines = File.ReadAllLines("LAB2.txt");
            double[] value = new double[lines.Length];
            for (int i = 0; i < value.Length; i++)
            {
                value[i] = float.Parse(lines[i]);
            }
            double xmin = value[0], xmax = value[1];
            
            using (StreamWriter writer = new StreamWriter("LAB2.res"))
            {
                Calculation(xmax,xmin,repeats,writer);
                writer.WriteLine("Розрахував студент группи КН-24-1 <Буханцев Максим Володимирович>");
            }
        }
    }
}
