using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Person
    {
        private string name;
        private string lastName;
        private DateTime birthDate;

        public Person(string name, string lastName, DateTime birthDate)
        {
            this.name = name;
            this.lastName = lastName;
            this.birthDate = birthDate;
        }
        public Person(string name, string lastName)
        {
            this.name = name;
            this.lastName = lastName;
            this.birthDate = DateTime.Now;

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
        public int BirthYear
        {
            get { return birthDate.Year; }
            set { birthDate = new DateTime(value, birthDate.Month, birthDate.Day); }
        }
        public int BirthMonth
        {
            get { return birthDate.Month; }
            set { birthDate = new DateTime(birthDate.Year, value, birthDate.Day); }
        }
        public int BirthDay
        { 
            get { return birthDate.Day; } 
            set { birthDate = new DateTime(birthDate.Year, birthDate.Month, value); }
        }
        public override string ToString()
        {
            return $"Имя: {name}\nФамилия: {lastName}\nДата рождения: {birthDate.ToShortDateString()}";
        }
        public string ToShortString()
        {
            return $"{name} {lastName}";
        }
        
        interface IName
        {

        }

    }
}
