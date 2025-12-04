using System.IO;
using System.Text;
using System.Text.Json;
using System.Windows;
using System.Windows.Controls;
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
    const string FilePath = "users.json";
    public MainWindow()
    {
        InitializeComponent();
    }

    private void BtnLogin_Click(object sender, RoutedEventArgs e)
    {
        string login = TxtLogin.Text;
        string password = TxtPassword.Password;

        if (!File.Exists(FilePath))
        {
            MessageBox.Show("База користувачів порожня. Спочатку зареєструйтесь.");
            return;
        }
        
        string json = File.ReadAllText(FilePath);
        var users = JsonSerializer.Deserialize<List<User>>(json);

        var user = users.FirstOrDefault(u => u.Username == login && u.Password == password);

        if (user != null)
        {
            MessageBox.Show($"Вітаємо, {user.FirstName}!", "Успіх");
        }
        else
        {
            MessageBox.Show("Невірний логін або пароль!", "Помилка");
        }
    }

    private void BtnRegister_Click(object sender, RoutedEventArgs e)
    {
        RegistrationWindow regWindow = new RegistrationWindow();
        regWindow.Show();
        this.Close(); 
    }

    private void Social_Click(object sender, RoutedEventArgs e)
    {
        MessageBox.Show("Вхід через соціальну мережу виконано успішно!", "Social Login");
    }
    private void BtnClose_Click(object sender, RoutedEventArgs e)
    {
        Application.Current.Shutdown();
    }
}