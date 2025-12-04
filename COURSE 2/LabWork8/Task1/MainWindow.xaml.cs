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
using Task1.Models;

namespace Task1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private MainViewModel Vm => (MainViewModel)DataContext;

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Add_Click(object sender, RoutedEventArgs e)
        {
            Student student = new Student();

            var dlg = new EditStudentWindow
            {
                Owner = this,
                DataContext = student
            };

            if (dlg.ShowDialog() == true)
            {
                if (!Vm.TryAddStudent(student, out string error))
                {
                    MessageBox.Show(error, "Помилка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (Vm.SelectedStudent == null)
            {
                MessageBox.Show("Оберіть студента для редагування.");
                return;
            }

            var copy = Vm.SelectedStudent.Clone();

            var dlg = new EditStudentWindow
            {
                Owner = this,
                DataContext = copy
            };

            if (dlg.ShowDialog() == true)
            {
                if (!Vm.TryUpdateStudent(Vm.SelectedStudent, copy, out string error))
                {
                    MessageBox.Show(error, "Помилка",
                        MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            var selected = StudentsList.SelectedItems.Cast<Student>().ToList();
            if (selected.Count == 0)
            {
                MessageBox.Show("Оберіть хоча б одного студента для видалення.");
                return;
            }

            var result = MessageBox.Show(
                $"Видалити {selected.Count} запис(ів)?",
                "Підтвердження",
                MessageBoxButton.YesNo,
                MessageBoxImage.Question);

            if (result == MessageBoxResult.Yes)
            {
                Vm.TryDeleteStudents(selected);
            }
        }
    }
}