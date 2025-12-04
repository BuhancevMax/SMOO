namespace Task4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines("input.txt");
            float[] value = new float[lines.Length];
            for (int i = 0; i < value.Length; i++)
            {
                value[i] = float.Parse(lines[i]);
            }
            float fuel = value[0] /*топливо*/ , AtoB = value[1] /*от А к В*/, BtoC = value[2] /*от В к С*/, weight = value[3] /*вес*/, a = 0 /*расход*/;
            if (weight <= 500 && a >= 0)
            {
                a = 1;
            }
            else if (weight < 1000 && weight >= 1000)
            {
                a = 4;
            }
            else if (weight < 1500 && weight >= 1500)
            {
                a = 7;
            }
            else if (weight <= 2000 && weight >= 2000)
            {
                a = 9;
            }
            else
            {
                Console.WriteLine("Вантаж занадто великий");
                return;
            }

            for (int i = 0; i < fuel && i < AtoB;)
            {
                if(fuel > a)
                {
                    fuel -= a;
                    AtoB -= 1;
                }
                else
                {
                    Console.WriteLine("Потрібно більше палива");
                    return;
                }
                
            }

            bool canRefuel = true;

            if((fuel / a) == BtoC)
            {
                for (int i = 0; i < fuel && i < BtoC;)
                {
                    if (fuel > a)
                    {
                        fuel -= a;
                        BtoC -= 1;
                    }
                }
                Console.WriteLine("Політ у точку С успішний!");
                return;
            }
            else
            {
                canRefuel = false;
                fuel += BtoC - fuel;
            }
            Console.WriteLine($"Дозаправка {BtoC - fuel}");

            for (int i = 0; i < fuel && i < BtoC;)
            {
                if (fuel > a)
                {
                    fuel -= a;
                    BtoC -= 1;
                }
            }
            Console.WriteLine("Політ у точку С успішний!");


        }
    }
}
