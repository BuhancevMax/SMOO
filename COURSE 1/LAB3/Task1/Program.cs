using System.Text;

namespace Task1
{
    internal class Program
    {
        static string filePath = "array.txt";
        static int arrLength = 10;
        
        static int[] arr = new int[arrLength];
        static int inputData = -1;
        static bool validInput = false;

        public static void TwoMinOfArray(int[] arr)
        {
            int sum = 0;
            int index1Min = -1, index2Min = -1;
            int min1 = int.MaxValue, min2 = int.MaxValue;
            for (int i = 0; i < arrLength; i++)
            {
                if (arr[i] < min1)
                {
                    min1 = arr[i];
                    index1Min = i;
                }
            }
            for (int i = 0; i < arrLength; i++)
            {
                if (arr[i] < min2 && arr[i] != min1)
                {
                    min2 = arr[i];
                    index2Min = i;
                }
            }

            int startIndex = Math.Min(index1Min, index2Min);
            int endIndex = Math.Max(index1Min, index2Min);

            for (int i = startIndex + 1; i < endIndex; i++)
            {
                sum += arr[i];
            }
            Console.WriteLine($"Мінімальні числа масиву: {min1} та {min2}");
            Console.WriteLine($"Сума чисел між ними: {sum}");
        }
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
                    validInput = false;
                }
            }
        }
        public static void WriteArrayFromFile(string path, ref int[] array)
        {
            
            try
            {
                string line = File.ReadLines(path).First();
                array = line.Split(',').Select(int.Parse).ToArray();
            }
            catch (Exception e)
            {
                Console.WriteLine($"Ошибка при записи массива!");
            }
        }
        public static void RandomInitArray(ref int[] array)
        {
            
            for (int i = 0; i < arrLength; i++)
            {
                array[i] = new Random().Next(1, 10);
            }
        }
        public static void PrintArray(int[] array)
        {
            foreach (var temp in array)
            {
                Console.Write($"{temp}, ");
            }
            Console.WriteLine();
        }
        public static void InitArray(ref int[] array)
        {
            
            for (int i = 0; i < arrLength; i++)
            {
                Console.WriteLine($"Введіть {i + 1} елемент масиву");
                CheckNum(ref array[i]);
            }
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.UTF8;
            Console.WriteLine("Як заповнити масив?\n1.Взяти з текстового файла\n2.Увести самому\n3.Зарандомити масив");
            do
            {
                CheckNum(ref inputData);
                switch (inputData)
                {
                    case 1:
                        WriteArrayFromFile(filePath, ref arr); break;

                    case 2:
                        InitArray(ref arr); break;

                    case 3:
                        RandomInitArray(ref arr); break;

                    default:
                        Console.WriteLine("Оберіть один з варіантів!");
                        validInput = false;
                        break;
                }
            } while (!validInput);

            PrintArray(arr);
            TwoMinOfArray(arr);
        }
    }
}
