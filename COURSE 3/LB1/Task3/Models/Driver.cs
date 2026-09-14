namespace Task3.Models;

public class Driver : Entity
{
    public string FullName { get; }
    public int ExperienceYears { get; }
    public decimal Balance { get; private set; }
    public bool IsAvailable { get; private set; }

    public Driver(int id, string fullName, int experienceYears, decimal balance) : base(id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(fullName);
        if (experienceYears < 0) throw new ArgumentOutOfRangeException(nameof(experienceYears), "Стаж повинен бути більше, або дорівнювати нулю.");
        if (balance < 0) throw new ArgumentOutOfRangeException(nameof(balance), "Баланс не може бути менше нуля.");
        
        FullName = fullName;
        ExperienceYears = experienceYears;
        Balance = balance;
        IsAvailable = true;
    }

    public void Assign()
    {
        IsAvailable = false;
    }
    public void Release()
    {
        IsAvailable = true;
    }
    public void ReceivePayment(decimal amount)
    {
        Balance += amount;
    }
    
}