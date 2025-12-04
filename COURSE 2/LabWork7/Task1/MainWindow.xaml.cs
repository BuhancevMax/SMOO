using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Data;
using Task1.Models;

namespace Task1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window, INotifyPropertyChanged
{
    private ObservableCollection<Candidate> _candidates;
    private ICollectionView _candidatesView;
    private Candidate _selectedCandidate;

    private bool _onlyWithExperience;
    private bool _onlyWithRecommendations;
    private string _educationFilter = "Уся";

    public ObservableCollection<Candidate> Candidates
    {
        get => _candidates;
        set
        {
            _candidates = value;
            OnPropertyChanged();
        }
    }

    public ICollectionView CandidatesView
    {
        get => _candidatesView;
        private set
        {
            _candidatesView = value;
            OnPropertyChanged();
        }
    }

    public Candidate SelectedCandidate
    {
        get => _selectedCandidate;
        set
        {
            _selectedCandidate = value;
            OnPropertyChanged();
        }
    }

    public bool OnlyWithExperience
    {
        get => _onlyWithExperience;
        set
        {
            if (_onlyWithExperience == value) return;
            _onlyWithExperience = value;
            OnPropertyChanged();
            CandidatesView?.Refresh();
        }
    }

    public bool OnlyWithRecommendations
    {
        get => _onlyWithRecommendations;
        set
        {
            if (_onlyWithRecommendations == value) return;
            _onlyWithRecommendations = value;
            OnPropertyChanged();
            CandidatesView?.Refresh();
        }
    }

    public string EducationFilter
    {
        get => _educationFilter;
        set
        {
            if (_educationFilter == value) return;
            _educationFilter = value;
            OnPropertyChanged();
            CandidatesView?.Refresh();
        }
    }

    public event PropertyChangedEventHandler? PropertyChanged;

    protected virtual void OnPropertyChanged([CallerMemberName] string? propertyName = null)
    {
        PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
    }
    
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        
        Candidates = new ObservableCollection<Candidate>();
        
        Candidates.Add(new Candidate
        {
            FullName = "Іваненко Іван Іванович",
            BirthDate = new DateTime(1995, 5, 10),
            Education = "Вища",
            EnglishLevel = "Володію вільно",
            GermanLevel = "Не знаю",
            FrenchLevel = "Читаю зі словником",
            HasComputerSkills = true,
            ExperienceYears = 5,
            HasRecommendations = true
        });

        Candidates.Add(new Candidate
        {
            FullName = "Петренко Петро Петрович",
            BirthDate = new DateTime(2000, 3, 1),
            Education = "Середня спеціальна",
            EnglishLevel = "Читаю зі словником",
            GermanLevel = "Не знаю",
            FrenchLevel = "Не знаю",
            HasComputerSkills = true,
            ExperienceYears = 1,
            HasRecommendations = false
        });
        
        CandidatesView = CollectionViewSource.GetDefaultView(Candidates);
        CandidatesView.Filter = FilterCandidate;
    }
    private bool FilterCandidate(object obj)
    {
        if (obj is not Candidate c) return false;

        if (OnlyWithExperience && c.ExperienceYears <= 0)
            return false;

        if (OnlyWithRecommendations && !c.HasRecommendations)
            return false;

        if (!string.IsNullOrEmpty(EducationFilter) && EducationFilter != "Уся")
        {
            if (c.Education != EducationFilter)
                return false;
        }

        return true;
    }
    private void Add_Click(object sender, RoutedEventArgs e)
    {
        var candidate = new Candidate
        {
            Education = "Вища",
            EnglishLevel = "Не знаю",
            GermanLevel = "Не знаю",
            FrenchLevel = "Не знаю"
        };

        var window = new EditCandidateWindow(candidate);
        if (window.ShowDialog() == true)
        {
            Candidates.Add(candidate);
        }
    }

    private void Edit_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedCandidate == null)
        {
            MessageBox.Show("Оберіть кандидата для редагування.");
            return;
        }

        var window = new EditCandidateWindow(SelectedCandidate);
        window.ShowDialog();
    }

    private void Delete_Click(object sender, RoutedEventArgs e)
    {
        if (SelectedCandidate == null)
        {
            MessageBox.Show("Оберіть кандидата для видалення.");
            return;
        }

        if (MessageBox.Show("Видалити обраного кандидата?",
                "Підтвердження",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question) == MessageBoxResult.Yes)
        {
            Candidates.Remove(SelectedCandidate);
        }
    }

    private void ResetFilter_Click(object sender, RoutedEventArgs e)
    {
        OnlyWithExperience = false;
        OnlyWithRecommendations = false;
        EducationFilter = "Уся";
    }
}