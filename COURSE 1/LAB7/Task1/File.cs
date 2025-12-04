
namespace Task1
{
    enum KindOf
    {
        SystemPrograms,  
        UserPrograms,    
        Documents        
    }
    class File : IComparable<File>, ICloneable
    {
        private string fileName;
        private Person userName;
        public DateTime dateOfLastEditing;

        public File(string fileName, Person userName, DateTime dateOfLastEditing)
        {
            FileName = fileName;
            UserName = userName;
            DateOfLastEditing = dateOfLastEditing;
        }
        public File()
        {
            fileName = " ";
            UserName = null;
            dateOfLastEditing = DateTime.Now;
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
        
        public override string ToString()
        {
            return $"Имя файла: {fileName}\nДата последнего редактирования: {dateOfLastEditing.ToShortDateString()}\nИмя пользователя: {userName.ToShortString()}\n\n";
        }

        public object Clone()
        {
             return new File(fileName, userName, dateOfLastEditing);
        }

        public int CompareTo(File? other)
        {
            if (ReferenceEquals(this, other)) return 0;
            
            if (other is null) return 1;
            
            var fileNameComparison = string.Compare(fileName, other.fileName, StringComparison.Ordinal);
            if (fileNameComparison != 0) return fileNameComparison;
            
            var userNameComparison = userName.CompareTo(other.userName);
            if (userNameComparison != 0) return userNameComparison;
            
            return dateOfLastEditing.CompareTo(other.dateOfLastEditing);
        }
    }
}
