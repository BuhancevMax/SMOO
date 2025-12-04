using System.IO;
using System.Text.Json;
using System.Windows;

namespace Task1;

public partial class RegistrationWindow : Window
{
    const string FilePath = "users.json";

        public RegistrationWindow()
        {
            InitializeComponent();
        }

        private void BtnSave_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(RegLogin.Text) || 
                string.IsNullOrWhiteSpace(RegPass.Text) ||
                string.IsNullOrWhiteSpace(RegName.Text))
            {
                MessageBox.Show("Заповніть обов'язкові поля (Логін, Пароль, Ім'я)!", "Помилка");
                return;
            }
            
            User newUser = new User
            {
                Username = RegLogin.Text,
                Password = RegPass.Text,
                FirstName = RegName.Text,
                LastName = RegSurname.Text,
                Gender = RbMale.IsChecked == true ? "Male" : "Female"
            };
            
            List<User> users = new List<User>();
            if (File.Exists(FilePath))
            {
                string existingJson = File.ReadAllText(FilePath);
                
                if (!string.IsNullOrWhiteSpace(existingJson))
                    users = JsonSerializer.Deserialize<List<User>>(existingJson) ?? new List<User>();
            }

            
            foreach (var u in users)
            {
                if (u.Username == newUser.Username)
                {
                    MessageBox.Show("Користувач з таким логіном вже існує!", "Помилка");
                    return;
                }
            }
            
            users.Add(newUser);
            string json = JsonSerializer.Serialize(users);
            File.WriteAllText(FilePath, json);

            MessageBox.Show("Реєстрація успішна!", "Успіх");
            
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }

        private void BtnBack_Click(object sender, RoutedEventArgs e)
        {
            MainWindow login = new MainWindow();
            login.Show();
            this.Close();
        }
    }
