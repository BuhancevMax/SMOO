namespace Task1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Product[] products = new Product[2];
            
            try
            {
                products[0] = Product.CreateProduct("Хлеб", new DateTime(2025, 3, 5), new DateTime(2025, 4, 25), 22.5);
                products[1] = Product.CreateMilkProduct("Молоко", new DateTime(2025, 4, 5), new DateTime(2025, 4, 10), 35.9, "Молоко Кременчука", 98.5);
                
            }
            catch (Exception ex) { Console.WriteLine(ex.Message); }

            Console.WriteLine("Дата сегодня: " + DateTime.Now + "\n");
            foreach (var obj in products)
            {
                Console.WriteLine(obj.ToString());
                Console.WriteLine("Продукт просрочен: " + obj.isExpired() + "\n");
            }
        }
    }
}
