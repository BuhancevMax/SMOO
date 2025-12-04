using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Task1.Models;

public class Candidate : INotifyPropertyChanged
{
    private string _fullName;
    private DateTime _birthDate = DateTime.Now.AddYears(-25);
    private string _education;
    private string _englishLevel;
    private string _germanLevel;
    private string _frenchLevel;
    private bool _hasComputerSkills;
    private int _experienceYears;
    private bool _hasRecommendations;
    
    public string FullName
    {
        get => _fullName;
        set => SetField(ref _fullName, value); 
    }

    public DateTime BirthDate
    {
        get => _birthDate;
        set
        {
            if (SetField(ref _birthDate, value))
            {
                OnPropertyChanged(nameof(BirthYear));
            }
        }
    }
    public int BirthYear => BirthDate.Year;
    
    public string Education
    {
        get => _education;
        set => SetField(ref _education, value); 
    }
    
    public string EnglishLevel
    {
        get => _englishLevel;
        set => SetField(ref _englishLevel, value);  
    }

    public string GermanLevel
    {
        get => _germanLevel;
        set => SetField(ref _germanLevel, value);
    }

    public string FrenchLevel
    {
        get => _frenchLevel;
        set => SetField(ref _frenchLevel, value);
    }

    public bool HasComputerSkills
    {
        get => _hasComputerSkills;
        set => SetField(ref _hasComputerSkills, value);
    }

    public int ExperienceYears
    {
        get => _experienceYears;
        set => SetField(ref _experienceYears, value);
    }

    public bool HasRecommendations
    {
        get => _hasRecommendations;
        set => SetField(ref _hasRecommendations, value);
    }
    
    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }

    protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
    {
        if (EqualityComparer<T>.Default.Equals(field, value)) return false;
        field = value;
        OnPropertyChanged(propertyName);
        return true;
    }
}