namespace Task1;

public class Company
{
    public string Name { get; }
    public DateTime FoundingDate { get; }
    public BusinessProfile Profile { get; }
    public DirectorInfo Director { get; }
    public int EmployeeCount { get; }
    public AddressInfo Address { get; }

    public Company(string name, DateTime foundingDate, BusinessProfile profile, DirectorInfo director, int employeeCount, AddressInfo address)
    {
        Name = name;
        FoundingDate = foundingDate;
        Profile = profile;
        Director = director;
        EmployeeCount = employeeCount;
        Address = address;
    }
    
    public override string ToString()
    {
        return $"Назва: {Name}, Заснована: {FoundingDate.ToShortDateString()}, Профіль: {Profile}, Директор: {Director.FullName}, Співробітники: {EmployeeCount}, Адреса: {Address.FullAddress}";
    }
}