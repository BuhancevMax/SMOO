namespace Task1
{
    internal class Program
    {
        private static void Main()
        {
            Action action = Delegates.ShowTime;
            action += Delegates.ShowDate;
            action += Delegates.ShowDayOfWeek;
            action.Invoke();
        
            Predicate<int> predicate = Delegates.IsPrime;
            predicate += Delegates.IsFibonacci;
            predicate.Invoke(13);
        
            Func<int, int, int> func = Delegates.SquareOfTriangle;
            Console.WriteLine(func(3, 4));
        
            Func<int, int, int> func2 = Delegates.SquareOfRectangle;
            Console.WriteLine(func2(3, 4));
        }
    }
}

