using System.Windows;
using Task1.Models;

namespace Task1;

public partial class EditCandidateWindow : Window
{
    public Candidate Candidate { get; }

    public EditCandidateWindow(Candidate candidate)
    {
        InitializeComponent();
        Candidate = candidate ?? throw new ArgumentNullException(nameof(candidate));
        DataContext = Candidate;
    }

    private void Ok_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Candidate.FullName))
        {
            MessageBox.Show("П.І.П. є обов'язковим.", "Помилка",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (Candidate.BirthDate > DateTime.Now.AddYears(-16))
        {
            MessageBox.Show("Кандидату має бути щонайменше 16 років.", "Помилка",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (Candidate.ExperienceYears < 0)
        {
            MessageBox.Show("Стаж не може бути від'ємним.", "Помилка",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        DialogResult = true;
        Close();
    }

    private void Cancel_Click(object sender, RoutedEventArgs e)
    {
        DialogResult = false;
        Close();
    }
}