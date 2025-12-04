using System.Windows;

namespace Task1;
public partial class Task2Window
{
    public Task2Window()
    {
        InitializeComponent();
    }
    
    private void HideButton_Click(object sender, RoutedEventArgs e)
    {
        VisibleTextBlock.Visibility = Visibility.Collapsed;
    }
    
    private void ShowButton_Click(object sender, RoutedEventArgs e)
    {
        VisibleTextBlock.Visibility = Visibility.Visible;
    }
}