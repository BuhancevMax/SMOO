using System.Globalization;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Task2;

/// <summary>
/// Interaction logic for MainWindow.xaml
/// </summary>
public partial class MainWindow : Window
{
    private Dictionary<string, double> _fuelPrices = new Dictionary<string, double>
        {
            { "А-95", 55.50 },
            { "А-92", 52.00 },
            { "ДП", 56.00 },
            { "Газ", 28.50 }
        };
    
        private double _dailyRevenue = 0;

        public MainWindow()
        {
            InitializeComponent();
            InitializeFuelData();
            this.Closing += MainWindow_Closing; 
        }

        private void InitializeFuelData()
        {
            foreach (var fuel in _fuelPrices)
            {
                FuelComboBox.Items.Add(fuel.Key);
            }
            FuelComboBox.SelectedIndex = 0; 
        }
        
        private void FuelComboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (FuelComboBox.SelectedItem == null) return;
            string selectedFuel = FuelComboBox.SelectedItem.ToString();
            
            if (_fuelPrices.TryGetValue(selectedFuel, out double price))
            {
                PriceTextBox.Text = price.ToString("F2");
                CalculateFuel(); 
            }
        }
        
        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
            if (TxtQuantity == null || TxtSumInput == null || GbFuelResult == null || LblFuelUnit == null) return;

            TxtQuantity.Text = "";
            TxtSumInput.Text = "";
            LblFuelTotal.Text = "0.00";

            if (RbQuantity.IsChecked == true)
            {
                TxtQuantity.IsReadOnly = false;
                TxtSumInput.IsReadOnly = true;
        
                TxtSumInput.Background = System.Windows.Media.Brushes.LightGray;
                TxtQuantity.Background = System.Windows.Media.Brushes.White;
                
                GbFuelResult.Header = "До оплати:";
                LblFuelUnit.Text = " грн.";
            }
            else
            {
                TxtQuantity.IsReadOnly = true;
                TxtSumInput.IsReadOnly = false;

                TxtQuantity.Background = System.Windows.Media.Brushes.LightGray;
                TxtSumInput.Background = System.Windows.Media.Brushes.White;
                
                GbFuelResult.Header = "До видачі:";
                LblFuelUnit.Text = " л.";
            }
            
            CalculateFuel();
        }
        
        private void FuelInput_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateFuel();
        }
        
        private void CalculateFuel()
        {
            if (FuelComboBox.SelectedItem == null || PriceTextBox == null) return;

            double price = double.Parse(PriceTextBox.Text);
            double result = 0;

            if (RbQuantity.IsChecked == true)
            {
                if (double.TryParse(TxtQuantity.Text, out double liters))
                {
                    result = liters * price;
                    LblFuelTotal.Text = result.ToString("F2");
                }
                else
                {
                    LblFuelTotal.Text = "0.00";
                }
            }
            else
            {
                if (double.TryParse(TxtSumInput.Text, out double sum))
                {
                    result = sum / price;
                    LblFuelTotal.Text = result.ToString("F2"); 
                }
                else
                {
                    LblFuelTotal.Text = "0.00";
                }
            }
        }
    
        private void Cafe_Checked(object sender, RoutedEventArgs e)
        { 
            ToggleCafeItem(CbHotDog, CountHotDog);
            ToggleCafeItem(CbHamburger, CountHamburger);
            ToggleCafeItem(CbFries, CountFries);
            ToggleCafeItem(CbCoke, CountCoke);

            CalculateCafe();
        }
        
        private void ToggleCafeItem(CheckBox cb, TextBox tb)
        {
            if (cb.IsChecked == true)
            {
                tb.IsEnabled = true;
                if (tb.Text == "0") tb.Text = ""; 
                tb.Focus();
            }
            else
            {
                tb.IsEnabled = false;
                tb.Text = "0";
            }
        }
        
        private void Cafe_TextChanged(object sender, TextChangedEventArgs e)
        {
            CalculateCafe();
        }
        
        private void CalculateCafe()
        {
            if (LblCafeTotal == null) return;

            double totalCafe = 0;

            totalCafe += GetItemCost(CbHotDog, PriceHotDog, CountHotDog);
            totalCafe += GetItemCost(CbHamburger, PriceHamburger, CountHamburger);
            totalCafe += GetItemCost(CbFries, PriceFries, CountFries);
            totalCafe += GetItemCost(CbCoke, PriceCoke, CountCoke);

            LblCafeTotal.Text = totalCafe.ToString("F2");
        }
        
        private double GetItemCost(CheckBox cb, TextBox priceTb, TextBox countTb)
        {
            if (cb.IsChecked == true)
            {
                if (double.TryParse(priceTb.Text, out double price) && 
                    int.TryParse(countTb.Text, out int count))
                {
                    return price * count;
                }
            }
            return 0;
        }
        
        private void BtnCalculate_Click(object sender, RoutedEventArgs e)
        {
            double fuelSum = 0;
            
            if (RbSum.IsChecked == true)
            {
                double.TryParse(TxtSumInput.Text, out fuelSum);
            }
            else
            {
                double.TryParse(LblFuelTotal.Text, out fuelSum);
            }

            double.TryParse(LblCafeTotal.Text, out double cafeSum);

            double total = fuelSum + cafeSum;
            
            LblTotalSum.Text = total.ToString("F2");
            
            _dailyRevenue += total;
        }
        
        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            MessageBox.Show($"Загальна виручка за день: {_dailyRevenue:F2} грн.", "Кінець зміни");
        }
    }