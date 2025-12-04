using System.Windows;

namespace Task1;

public partial class MainWindow
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void OpenTask1_Click(object sender, RoutedEventArgs e)
    {
        Task1Window task1Window = new Task1Window();
        task1Window.Show();
    }
    
    private void OpenTask2_Click(object sender, RoutedEventArgs e)
    {
        Task2Window task2Window = new Task2Window();
        task2Window.Show();
    }
    
    private void OpenTask3_Click(object sender, RoutedEventArgs e)
    {
        Task3Window task3Window = new Task3Window();
        task3Window.Show();
    }
    
    private void OpenTask4_Click(object sender, RoutedEventArgs e)
    {
        Task4Window task4Window = new Task4Window();
        task4Window.Show();
    }
    
    private void OpenTask5_Click(object sender, RoutedEventArgs e)
    {
        Task5Window task5Window = new Task5Window();
        task5Window.Show();
    }
    
    private void OpenTask6_Click(object sender, RoutedEventArgs e)
    {
        Task6Window task6Window = new Task6Window();
        task6Window.Show();
    }
}