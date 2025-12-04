using System.Linq.Expressions;

namespace Task3
{
    internal class Program
    {
        static int PCnum;
        static int PCscore = 0;
        static int inputNum = 0;
        static int score = 0;
        static int HP = 5;
        static bool hardMode = false;
        static bool isHardModeDone = false;
        static int rounds = 3;
        public static void CheckNum(ref int num) // ПРОВЕРКА | ПРОВЕРКА | ПРОВЕРКА | ПРОВЕРКА | ПРОВЕРКА | ПРОВЕРКА |
        {
            while (true)
            {
                string input = Console.ReadLine();
                
                if (int.TryParse(input, out num))
                {
                    break;
                }
                else
                {
                    Console.WriteLine("Неверно введено число, повтори попытку");
                }
            }
        }
        public static void Clue() // ПОДСКАЗКА | ПОДСКАЗКА | ПОДСКАЗКА | ПОДСКАЗКА | ПОДСКАЗКА | ПОДСКАЗКА |
        {
            Console.WriteLine("Введи число, и компьютер подскажет - оно больше или меньше загаданного: ");
            CheckNum(ref inputNum);
            if (inputNum > PCnum)
            {
                Console.WriteLine("Загаданное число меньше введенного!");
            }
            else if (inputNum < PCnum)
            {
                Console.WriteLine("Загаданное число больше введенного!");
            }
            else if(inputNum==PCnum){

                Console.WriteLine("Вы близки к истине!\n");
            }
            
        }
        public static void Game() // ИГРА || ИГРА || ИГРА || ИГРА || ИГРА || ИГРА || ИГРА || 
        {
            Random random = new Random();
            int corner1 = 1, corner2 = 10, wayToHard = 0;
            
            for (int i = 0; i < rounds; i++) 
            {               
                HP = hardMode ? 23 : 5;
                if (hardMode)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("ХАРДКОРНЫЙ РЕЖИМ\n");
                    Console.WriteLine($"{i + 1}-й раунд");
                    Console.ResetColor();

                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{i + 1}-й раунд");
                    Console.ResetColor();
                }

                PCnum = random.Next(corner1, corner2);

                while (true)
                {
                    Console.WriteLine("Напишите \"0\" если хотите подсказку (-1 жизнь)");
                    Console.WriteLine($"Очки компьютера: {PCscore}\nМои очки: {score}\nМои жизни: {HP}\nКомпьютер загадал число, попробуй угадать: ");
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"Число компа - {PCnum} ");
                    Console.ResetColor();

                    CheckNum(ref inputNum);
                    if (inputNum == PCnum)
                    {
                        Console.WriteLine("Вы угадали число!\n");
                        score += HP * 5;
                        wayToHard++;

                        if (wayToHard == 3 && !hardMode) 
                        {                           
                            corner1 = 10;
                            corner2 = 100;
                            hardMode = true;
                            rounds = 2;
                            HP = 23;
                            i = -1; 
                            wayToHard = 0; 
                            break;
                        }

                        Console.WriteLine("Хотите ли вы продолжить?\n1.Да\n2.Нет");
                        CheckNum(ref inputNum);
                        if (inputNum == 2)
                        {
                            Console.WriteLine($"Твои очки: {score}\nОчки компьютера: {PCscore} \n");
                            return;
                        }
                        else if (inputNum == 1)
                        {
                            HP = 5;
                            
                            break; // переход к следующему раунду
                        }
                    }
                    else if (inputNum == 0)
                    {
                        Clue();
                        HP--;
                    }
                    else
                    {
                        Console.WriteLine("Вы не угадали число!\n");
                        HP--;
                    }
                    if (HP == 0)
                    {
                        if (!hardMode)
                        {
                            PCscore += 5 * 5;
                        }
                        else
                        {
                            PCscore += 23 * 10;
                        }

                        wayToHard = 0;
                        Console.WriteLine("Вы проиграли раунд!");
                        Console.WriteLine("Хотите ли вы продолжить?\n1.Да\n2.Нет");
                        
                        CheckNum(ref inputNum);
                        if (inputNum == 2)
                        {

                            Console.WriteLine($"Твои очки: {score}\nОчки компьютера: {PCscore} \n");
                            return;
                        }
                        else if (inputNum == 1)
                        {
                            i--;
                            break;
                        }
                    }                  
                } 
            }
            Console.WriteLine("Игра окончена!");
            Console.WriteLine($"Твои очки: {score}\nОчки компьютера: {PCscore} \n");
        }
        static void Main(string[] args)
        {
            Console.WriteLine("*GUESS MY NUMBER*\n");
            Game();
        }
    }
}


