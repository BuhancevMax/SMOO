using System.Windows;
using Task1.Models;

namespace Task1;

public partial class EditStudentWindow : Window
{
    private Student Student => (Student)DataContext;

    public EditStudentWindow()
    {
        InitializeComponent();
    }

    private void Ok_Click(object sender, RoutedEventArgs e)
    {
        if (string.IsNullOrWhiteSpace(Student.LastName))
        {
            MessageBox.Show("Прізвище є обов'язковим.", "Помилка",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(Student.FirstName))
        {
            MessageBox.Show("Ім'я є обов'язковим.", "Помилка",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (string.IsNullOrWhiteSpace(Student.Gender))
        {
            MessageBox.Show("Стать є обов'язковою.", "Помилка",
                MessageBoxButton.OK, MessageBoxImage.Error);
            return;
        }

        if (Student.Age < 0)
        {
            MessageBox.Show("Вік не може бути від'ємним.", "Помилка",
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