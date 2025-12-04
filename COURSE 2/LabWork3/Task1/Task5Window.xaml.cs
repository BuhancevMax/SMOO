using System.Windows;

namespace Task1;

public partial class Task5Window
{
    private const double PoundsToKgFactor = 0.453592;
    
    public Task5Window()
    {
        InitializeComponent();
    }

    private void CalculateButton_Click(object sender, RoutedEventArgs e)
    {
        string inputText = PoundsTextBox.Text;
        
        if (double.TryParse(inputText, out double pounds))
        {
            double kilograms = pounds * PoundsToKgFactor;
            
            kilograms = Math.Round(kilograms, 3);
            
            ResultTextBlock.Text = $"{pounds} фунтів = {kilograms} кілограмів";
        }
        else
        {
            MessageBox.Show(
                "Будь ласка, введіть коректне числове значення.", 
                "Помилка вводу", 
                MessageBoxButton.OK, 
                MessageBoxImage.Error
            );
            ResultTextBlock.Text = string.Empty;
        }
    }
}