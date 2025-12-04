using System.Collections.ObjectModel;
using System.ComponentModel;
using System.IO;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Task1.Models;

public class MainViewModel : INotifyPropertyChanged
    {
        private readonly string _filePath;
        private Student? _selectedStudent;

        public ObservableCollection<Student> Students { get; } = new();

        public Student? SelectedStudent
        {
            get => _selectedStudent;
            set
            {
                if (_selectedStudent == value) return;
                _selectedStudent = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(HasSelection));
            }
        }

        public bool HasStudents => Students.Count > 0;
        public bool HasSelection => SelectedStudent != null;

        public MainViewModel()
        {
            _filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Students.xml");

            Students.CollectionChanged += (_, __) =>
            {
                OnPropertyChanged(nameof(HasStudents));
            };

            LoadFromXml();
        }

        private void LoadFromXml()
        {
            if (!File.Exists(_filePath)) return;

            try
            {
                var serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("Students"));
                using var fs = File.OpenRead(_filePath);
                if (serializer.Deserialize(fs) is List<Student> list)
                {
                    Students.Clear();
                    foreach (var s in list)
                        Students.Add(s);
                }
            }
            catch
            {
            }
        }

        private void SaveToXml()
        {
            var serializer = new XmlSerializer(typeof(List<Student>), new XmlRootAttribute("Students"));
            using var fs = File.Create(_filePath);
            serializer.Serialize(fs, Students.ToList());
        }
        
        public bool TryAddStudent(Student student, out string error)
        {
            if (!Validate(student, out error))
                return false;

            Students.Add(student);
            SaveToXml();
            return true;
        }

        public bool TryUpdateStudent(Student target, Student updated, out string error)
        {
            if (target == null)
            {
                error = "Не вибрано студента.";
                return false;
            }

            if (!Validate(updated, out error))
                return false;

            target.FirstName = updated.FirstName;
            target.LastName = updated.LastName;
            target.Age = updated.Age;
            target.Gender = updated.Gender;

            SaveToXml();
            return true;
        }

        public bool TryDeleteStudents(IEnumerable<Student> students)
        {
            var list = students.ToList();
            if (list.Count == 0) return false;

            foreach (var s in list)
                Students.Remove(s);

            SaveToXml();
            return true;
        }

        private bool Validate(Student s, out string error)
        {
            if (string.IsNullOrWhiteSpace(s.LastName))
            {
                error = "Прізвище є обов'язковим.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(s.FirstName))
            {
                error = "Ім'я є обов'язковим.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(s.Gender))
            {
                error = "Стать є обов'язковою.";
                return false;
            }

            if (s.Age < 16 || s.Age > 100)
            {
                error = "Вік повинен бути в діапазоні від 16 до 100 років.";
                return false;
            }

            error = "";
            return true;
        }

        public event PropertyChangedEventHandler? PropertyChanged;
        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
    }