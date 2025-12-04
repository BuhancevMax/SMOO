using System.Windows;

namespace Task1;

public partial class Task1Window
{
    public Task1Window()
    {
        InitializeComponent();
    }
    
    private void HelloButton_Click(object sender, RoutedEventArgs e)
    {
        InfoLabel.Content = "Привіт";
    }
    
    private void GoodbyeButton_Click(object sender, RoutedEventArgs e)
    {
        InfoLabel.Content = "До побачення";
    }
}