using System.Windows;

namespace Task1;

public partial class Task3Window 
{
    public Task3Window()
    {
        InitializeComponent();
    }
    
    private void HideButton_Click(object sender, RoutedEventArgs e)
    {
        ManagedTextBox.Visibility = Visibility.Hidden;
    }
    
    private void ShowButton_Click(object sender, RoutedEventArgs e)
    {
        ManagedTextBox.Visibility = Visibility.Visible;
    }
    
    private void ClearButton_Click(object sender, RoutedEventArgs e)
    {
        ManagedTextBox.Clear();
    }
}