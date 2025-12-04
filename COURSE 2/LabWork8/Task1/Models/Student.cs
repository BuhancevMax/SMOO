using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Xml.Serialization;

namespace Task1.Models;

[XmlType("Student")]
    public class Student : INotifyPropertyChanged
    {
        private string _firstName = "";
        private string _lastName = "";
        private int _age;
        private string _gender = "";

        public string FirstName
        {
            get => _firstName;
            set => SetField(ref _firstName, value);
        }

        public string LastName
        {
            get => _lastName;
            set => SetField(ref _lastName, value);
        }

        public int Age
        {
            get => _age;
            set
            {
                if (SetField(ref _age, value))
                    OnPropertyChanged(nameof(AgeDisplay));
            }
        }

        public string Gender
        {
            get => _gender;
            set => SetField(ref _gender, value);
        }
        
        [XmlIgnore]
        public string FullName => $"{LastName} {FirstName}";

        [XmlIgnore]
        public string AgeDisplay => $"{Age} {GetAgePostfix(Age)}";

        private static string GetAgePostfix(int age)
        {
            int lastTwo = age % 100;
            int last = age % 10;

            if (lastTwo is >= 11 and <= 14)
                return "років";

            return last switch
            {
                1 => "рік",
                2 or 3 or 4 => "роки",
                _ => "років"
            };
        }

        public Student Clone() =>
            new Student
            {
                FirstName = FirstName,
                LastName = LastName,
                Age = Age,
                Gender = Gender
            };

        public event PropertyChangedEventHandler? PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string? name = null) =>
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));

        protected bool SetField<T>(ref T field, T value, [CallerMemberName] string? propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(field, value)) return false;
            field = value;
            OnPropertyChanged(propertyName);
            return true;
        }
    }