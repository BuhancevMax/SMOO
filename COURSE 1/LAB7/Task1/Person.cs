

namespace Task1
{
    class Person : IComparable<Person>, ICloneable
    {
        private string name;
        private string lastName;
        private DateTime birthDate;

        public Person(string name, string lastName, DateTime birthDate)
        {
            Name = name;
            LastName = lastName;
            BirthDate = birthDate;
        }
        public Person(string name, string lastName)
        {
            Name = name;
            LastName = lastName;
            BirthDate = DateTime.Now;

        }
        public Person(string name)
        {
            Name = name;
        }
        public Person()
        {
            this.name = " ";
            this.lastName = " ";
            this.birthDate = DateTime.Now;
        }
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public string LastName
        {
            get { return lastName; }
            set { lastName = value; }
        }
        public DateTime BirthDate
        {
            get { return birthDate; }
            set { birthDate = value; }
        }
        

        public override string ToString()
        {
            return $"Имя пользователя: {name}\nФамилия: {lastName}\nДата рождения: {birthDate.ToShortDateString()}";
        }

        public object Clone()
        {
            return new Person(name, lastName, birthDate);
        }

        public string ToShortString()
        {
            return $"{name} {lastName}";
        }
        
        public int CompareTo(Person? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            if (other is null) return 1;
            var nameComparison = string.Compare(name, other.name, StringComparison.Ordinal);
            if (nameComparison != 0) return nameComparison;
            var lastNameComparison = string.Compare(lastName, other.lastName, StringComparison.Ordinal);
            if (lastNameComparison != 0) return lastNameComparison;
            return birthDate.CompareTo(other.birthDate);
        }
    }
}
