using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task1;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private string _currentNumber = "0"; 
    private string _currentOperation = ""; 
    private string _history = ""; 
    private double _lastNumber = 0; 
    private bool _isNewEntry = true; // Чи починається введення нового числа (після операції)
    
    public MainWindow()
    {
        InitializeComponent();
        UpdateDisplay();
    }

    private void ButtonNumber_Click(object sender, RoutedEventArgs e)
    {
        string digit = (sender as Button).Content.ToString();
        
        if (_currentNumber == "0" || _isNewEntry)
        {
            _currentNumber = digit;
            _isNewEntry = false; 
        }
        else
        {
            _currentNumber += digit;
        }

        UpdateDisplay();
    }
    private void ButtonOperation_Click(object sender, RoutedEventArgs e)
    {
        string operation = (sender as Button).Content.ToString();
            
        // Виконуємо попередню операцію, якщо вона була
        if (!_isNewEntry)
        {
            Calculate();
        }

        _lastNumber = double.Parse(_currentNumber);
        _currentOperation = operation;
        _history = $"{_currentNumber} {_currentOperation}"; // Оновлюємо історію
        _isNewEntry = true; // Наступний клік по цифрі почне нове число

        UpdateDisplay();
    }
    private void ButtonEquals_Click(object sender, RoutedEventArgs e)
    {
        Calculate();
        _history = ""; // Очищуємо історію після обчислення
        _currentOperation = "";
        _isNewEntry = true; // Готові до нового ланцюжка обчислень
        UpdateDisplay();
    }
    private void ButtonDecimal_Click(object sender, RoutedEventArgs e)
    {
        if (_isNewEntry)
        {
            _currentNumber = "0,";
            _isNewEntry = false;
        }
        else if (!_currentNumber.Contains(","))
        {
            _currentNumber += ",";
        }
        UpdateDisplay();
    }
    private void ButtonBackspace_Click(object sender, RoutedEventArgs e)
    {
        if (!_isNewEntry && _currentNumber.Length > 0)
        {
            _currentNumber = _currentNumber.Substring(0, _currentNumber.Length - 1);
            if (string.IsNullOrEmpty(_currentNumber))
            {
                _currentNumber = "0";
                _isNewEntry = true;
            }
        }
        UpdateDisplay();
    }
    private void ButtonC_Click(object sender, RoutedEventArgs e)
    {
        // Повне скидання стану
        _currentNumber = "0";
        _lastNumber = 0;
        _currentOperation = "";
        _history = "";
        _isNewEntry = true;
        UpdateDisplay();
    }
    private void ButtonCE_Click(object sender, RoutedEventArgs e)
    {
        // Скидає тільки поточне введення
        _currentNumber = "0";
        _isNewEntry = true;
        UpdateDisplay();
    }
    private void Calculate()
    {
        if (string.IsNullOrEmpty(_currentOperation))
            return;

        double currentNum = double.Parse(_currentNumber);
        double result = 0;

        switch (_currentOperation)
        {
            case "+":
                result = _lastNumber + currentNum;
                break;
            case "-":
                result = _lastNumber - currentNum;
                break;
            case "*":
                result = _lastNumber * currentNum;
                break;
            case "/":
                if (currentNum != 0)
                {
                    result = _lastNumber / currentNum;
                }
                else
                {
                    // Обробка ділення на нуль
                    MessageBox.Show("Ділення на нуль неможливе.", "Помилка", MessageBoxButton.OK, MessageBoxImage.Error);
                    ButtonC_Click(null, null); // Повне скидання
                    return;
                }
                break;
        }
        _currentNumber = result.ToString();
    }
    private void UpdateDisplay()
    {
        CurrentDisplay.Text = _currentNumber;
        HistoryDisplay.Text = _history;
    }
}