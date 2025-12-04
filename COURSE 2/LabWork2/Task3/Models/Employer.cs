namespace Task3.Models;

public abstract class Employer
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public DateTime DateOfBirth { get; set; }
    public DateTime HireDate { get; set; }
    public decimal Salary { get; set; }
    public bool HasHigherEducation { get; set; }
    
    public int Age => (int)((DateTime.Now - DateOfBirth).TotalDays / 365);
    public TimeSpan WorkExperience => DateTime.Now - HireDate;

    public override string ToString()
    {
        return $"{FirstName} {LastName}, Вік: {Age}, Посада: {this.GetType().Name}, Зарплата: {Salary:C}";
    }
}