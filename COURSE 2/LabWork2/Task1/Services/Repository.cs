namespace Task1.Services;

public class Repository
{
    private List<Company> Companies;

    public Repository()
    {
        Companies = new List<Company>
        {
            new Company("SoftServe", new DateTime(1991, 8, 1), BusinessProfile.IT, new DirectorInfo("Oleg Denys"), 12000, new AddressInfo("Lviv, Naukova St, 7", "Lviv")),
            new Company("Food Express Ltd", new DateTime(2023, 11, 25), BusinessProfile.Food, new DirectorInfo("Anna White"), 15, new AddressInfo("Kyiv, Khreshchatyk, 1", "Kyiv")),
            new Company("Global Marketing", new DateTime(2021, 5, 10), BusinessProfile.Marketing, new DirectorInfo("Victor Green"), 250, new AddressInfo("London, Baker Street, 221B", "London")),
            new Company("IT Solutions Inc", new DateTime(2018, 1, 15), BusinessProfile.IT, new DirectorInfo("Ivan Black"), 50, new AddressInfo("Lviv, Shevchenko St, 1", "Lviv")),
            new Company("Innovate Marketing", new DateTime(2024, 1, 1), BusinessProfile.Marketing, new DirectorInfo("Maria White"), 105, new AddressInfo("New York, Wall Street, 10", "New York")),
            new Company("Food Market", new DateTime(2022, 6, 1), BusinessProfile.Food, new DirectorInfo("Olena White"), 800, new AddressInfo("London, Piccadilly Circus", "London")),
            new Company("Consulting Pro", new DateTime(2023, 1, 1), BusinessProfile.Consulting, new DirectorInfo("Tom Blue"), 5, new AddressInfo("London, Whitehall", "London"))
        };
    }

    public IEnumerable<Company> GetAll() => Companies;
}