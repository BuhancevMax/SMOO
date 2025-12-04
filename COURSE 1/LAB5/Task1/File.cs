using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    enum KindOf
    {
        SystemPrograms,  
        UserPrograms,    
        Documents        
    }
    class File
    {
        private string fileName;
        private Person userName;
        public DateTime dateOfLastEditing;

        public File(string fileName, Person userName, DateTime dateOfLastEditing)
        {
            this.fileName = fileName;
            this.userName = userName;
            this.dateOfLastEditing = dateOfLastEditing;
        }
        public File()
        {
            this.fileName = " ";
            this.userName = userName;
            this.dateOfLastEditing = DateTime.Now;
        }
        public string FileName
        {
            get { return fileName; }
            set { fileName = value; }
        }
        public Person UserName
        {
            get { return userName; }
            set { userName = value; }
        }
        public DateTime DateOfLastEditing
        {
            get { return dateOfLastEditing; }
            set { dateOfLastEditing = value; }
        }
        public int YearOfLastEditing
        {
            get { return dateOfLastEditing.Year; }
            set { dateOfLastEditing = new DateTime(value, dateOfLastEditing.Month, dateOfLastEditing.Day); }
        }
        public int MonthOfLastEditing
        {
            get { return dateOfLastEditing.Month; }
            set { dateOfLastEditing = new DateTime(dateOfLastEditing.Year, value, dateOfLastEditing.Day); }
        }
        public int DayOfLastEditing
        {
            get { return dateOfLastEditing.Day; }
            set { dateOfLastEditing = new DateTime(dateOfLastEditing.Year, dateOfLastEditing.Month, value); }
        }
        public override string ToString()
        {
            return $"Имя файла: {fileName}\nИмя пользователя: {userName}\nДата последнего редактирования: {dateOfLastEditing.ToShortDateString()}\n";
        }

    }
}
