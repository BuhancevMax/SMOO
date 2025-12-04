using System.Text;

namespace Task2
{
    internal class Program
    {
        static string filePath = "2Darray.txt";
        static int arrLength;

        static int[,] graph;
        const int INF = 99;
        static int inputData = -1;
        static bool validInput = false;

        public static void CheckNum(ref int num)
        {
            while (true)
            {
                string input = Console.ReadLine();

                if (int.TryParse(input, out num))
                {
                    validInput = true;
                    break;
                }
                else
                {
                    Console.WriteLine("Incorrect number entered, try again");
                }
            }
        }
        public static void WriteArrayFromFile(string path, ref int[,] array)
        {
            try
            {
                string[] lines = File.ReadAllLines(path);
                arrLength = lines.Length;
                array = new int[arrLength, arrLength];

                for (int i = 0; i < arrLength; i++)
                {
                    int[] row = lines[i].Split(' ').Select(int.Parse).ToArray();
                    for (int j = 0; j < arrLength; j++)
                    {
                        if(row[j] == 0 && i != j)
                        {
                            array[i, j] = INF;
                        }
                        else
                        {
                            array[i, j] = row[j];
                        }
                       
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("Ошибка при чтении файла!");
            }
        }
        public static void RandomInitArray(ref int[,] array)
        {
            Random rand = new Random();
            for (int i = 0; i < arrLength; i++)
            {
                for (int j = 0; j < arrLength; j++)
                {
                    if (i == j)
                    {
                        array[i, j] = 0;
                    }
                    else
                    {
                        if (rand.Next(0, 10) > 3)               // 70% шанс на дорогу
                        {
                            array[i, j] = rand.Next(1, 20);        
                        }
                        else
                        {
                            array[i, j] = INF;
                        }
                    }
                }
            }
        }
        public static void PrintArray(int[,] array)
        {
            for (int i = 0; i < arrLength; i++)
            {
                for (int j = 0; j < arrLength; j++)
                {
                    Console.Write(array[i, j] == INF ? "INF " : array[i, j] + "  ");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
        }
        public static void InitArray(ref int[,] array)
        {
            for (int i = 0; i < arrLength; i++)
            {
                for (int j = 0; j < arrLength; j++)
                {
                    if (i == j)
                    {
                        array[i, j] = 0;
                        continue;
                    }
                    Console.WriteLine($"Введите расстояние между городами {i + 1} и {j + 1} (0 = нет дороги):");
                    CheckNum(ref array[i, j]);
                    if (array[i, j] == 0) array[i, j] = INF;
                }
            }
        }
        public static void ShimbleMethod(ref int[,] array)
        {
            for (int k = 0; k < arrLength; k++)
            {
                for (int i = 0; i < arrLength; i++)
                {
                    for (int j = 0; j < arrLength; j++)
                    {
                        if (array[i, k] != INF && array[k, j] != INF)
                        {
                            array[i, j] = Math.Min(array[i, j], array[i, k] + array[k, j]);
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Введіть кількість міст:");
            CheckNum(ref arrLength);
            graph = new int[arrLength, arrLength];

            Console.WriteLine("Як заповнити матрицю?\n1.Взяти з текстового файла\n2.Увести самому\n3.Зарандомити матрицю");
            do
            {
                CheckNum(ref inputData);
                switch (inputData)
                {
                    case 1:
                        WriteArrayFromFile(filePath, ref graph); break;

                    case 2:
                        InitArray(ref graph); break;

                    case 3:
                        RandomInitArray(ref graph); break;

                    default:
                        Console.WriteLine("Оберіть один з варіантів!");
                        validInput = false;
                        break;
                }
            } while (!validInput);

            Console.WriteLine("Початкова матриця:");
            PrintArray(graph);

            ShimbleMethod(ref graph);

            Console.WriteLine("Матриця найкоротших шляхів:");
            PrintArray(graph);
        }
    }
}
