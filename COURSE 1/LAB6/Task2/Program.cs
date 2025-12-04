namespace Task2
{
    internal class Program
    {
        public static void SortOrganizations(Organization[] organizations)
        {
            Console.WriteLine("\nОтсортированые организации по количеству инженеров: \n");
            Array.Sort(organizations, (o1, o2) => o1.AmountOfEngineers.CompareTo(o2.AmountOfEngineers));
        }

        public static void PrintInfo(Organization[] organizations)
        {
            foreach (var obj in organizations)
            {
                Console.WriteLine(obj);
            }
        }
        
        static void Main(string[] args)
        {
            Organization[] organizations = new Organization[]
            {
                new Factory("НКМЗ", 180, 40),
                new InsuranceCompany("Страховка - легко",50, 20),
                new ShipbuildingCompany("Кораблик", 100, 30),
                new Factory("Заводик", 200, 90),
                new InsuranceCompany("Страховочка",100, 35),
            };

            PrintInfo(organizations);

            SortOrganizations(organizations);

            PrintInfo(organizations);
        }
    }
}
