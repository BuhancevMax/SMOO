namespace Task3.Models;

public class Company
{
    public string Name { get; set; }
    public List<Employer> Employers { get; }

    public Company(string name)
    {
        Name = name;
        Employers = new List<Employer>();
    }

    public void HireEmployer(Employer employer)
    {
        Employers.Add(employer);
    }
}