using System.Windows;
using System.Windows.Controls;

namespace Task1;

public partial class Task4Window : Window
{
    public Task4Window()
    {
        InitializeComponent();
    }
    
    private void ToggleVisibility(Button btn)
    {
        if (btn.Visibility == Visibility.Visible)
        {
            btn.Visibility = Visibility.Collapsed;
        }
        else
        {
            btn.Visibility = Visibility.Visible;
        }
    }
    
    private void Button_Click(object sender, RoutedEventArgs e)
    {
        if (sender is Button clickedButton)
        {
            switch (clickedButton.Name)
            {
                case "Button1":
                    ToggleVisibility(Button1);
                    ToggleVisibility(Button2);
                    break;
                
                case "Button2":
                    ToggleVisibility(Button1);
                    ToggleVisibility(Button2);
                    ToggleVisibility(Button3);
                    break;
                
                case "Button3":
                    ToggleVisibility(Button2);
                    ToggleVisibility(Button3);
                    ToggleVisibility(Button4);
                    break;
                
                case "Button4":
                    ToggleVisibility(Button3);
                    ToggleVisibility(Button4);
                    ToggleVisibility(Button5);
                    break;
                
                case "Button5":
                    ToggleVisibility(Button4);
                    ToggleVisibility(Button5);
                    break;
            }
        }
        
        CheckForWin();
    }
    
    private void CheckForWin()
    {
        bool allHidden = ButtonPanel.Children.OfType<Button>().All(btn => btn.Visibility == Visibility.Collapsed);

        if (allHidden)
        {
            WinLabel.Visibility = Visibility.Visible;
        }
        else
        {
            WinLabel.Visibility = Visibility.Collapsed; 
        }
    }
}