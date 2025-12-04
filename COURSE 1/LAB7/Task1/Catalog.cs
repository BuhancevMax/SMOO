using System.IO;
using System.Collections;

namespace Task1
{
    interface IContainer
    {
        int Count { get; }
        Object this[int index] { get; set; }
        void Add(Object element);
        void Delete(Object element);
    }

    interface IFileContainer : IContainer
    {
        void Save(String fileName);
        void Load(String fileName);
        Boolean IsDataSaved { get; set; }
    }
    
     class Catalog : IFileContainer, IEnumerable<File>, IEnumerator<File>
    {
        private string catalogName;
        private string description;
        private int sizeOfCatalog;
        private KindOf kindOfCatalog;
        private static File[] files = new File[0];

        public Catalog(string catalogName, string description, int sizeOfCatalog, KindOf kindOfCatalog, File[] files)
        {
            CatalogName = catalogName;
            Description = description;
            SizeOfCatalog = sizeOfCatalog;
            KindOfCatalog = kindOfCatalog;
            Files = files;
        }
        public Catalog(string catalogName, string description, int sizeOfCatalog, KindOf kindOfCatalog)
        {
            CatalogName = catalogName;
            Description = description;
            SizeOfCatalog = sizeOfCatalog;
            KindOfCatalog = kindOfCatalog;
            Files = files;
        }
        public Catalog()
        {
            catalogName = " ";
            description = " ";
            sizeOfCatalog = 0;
            kindOfCatalog = KindOf.SystemPrograms;
            Files = new File[]{null};
        }
        public string CatalogName
        {
            get { return catalogName; }
            set { catalogName = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Название не может быть пустым!") : value; }
        }
        public string Description
        {
            get { return description; }
            set { description = value; }
        }
        public int SizeOfCatalog
        {
            get { return sizeOfCatalog; }
            set { sizeOfCatalog = value >= 0 ? value : throw new ArgumentException("Размер не может быть отрицательным!"); }
        }
        public KindOf KindOfCatalog
        {
            get { return kindOfCatalog; }
            set { kindOfCatalog = value; }
        }
        public File[] Files
        {
            get { return files; }
            set { files = value; }
        }

        public IEnumerator<File> GetEnumerator()
        {
            return this;
        }

        public override string ToString()
        {
            string result = $"Имя каталога: {catalogName}\nОписание: {description}\nРазмер каталога: {sizeOfCatalog}\nТип каталога: {kindOfCatalog}\nФайлы в каталоге:\n\n";
            foreach (var file in files)
            {
                result += file + "\n";
            }
            return result;
        }

        public void Dispose()
        { }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }

        public string ToShortString()
        {
            return $"Имя каталога: {catalogName}\nТип каталога: {kindOfCatalog}\n";
        }
        
        public bool this[KindOf index]
        {
            get { return kindOfCatalog == index ? true : false; }
        }

        
        public void PrintIndexerOfCatalog()
        {
            Console.WriteLine("SystemPrograms: " + KindOf.SystemPrograms);
            Console.WriteLine("UserPrograns: " + KindOf.UserPrograms);
            Console.WriteLine("Documents: " + KindOf.Documents + "\n");
        }
        public File CreateFile(string nameFile, Person userName, DateTime dateFile)
        {
            File file = new File(nameFile, userName, dateFile);
            Add(file);
            return file;
        }
        // ============================================================================================================
        public int Count { get; }

        public object this[int index]
        {
            get => (index < 0 || index >= files.Length) ? throw new IndexOutOfRangeException() : files[index];
            set => files[index] = (File)value;
        }

        public void Add(object element)
        {
            if (element is File file)
            {
                Array.Resize(ref files, files.Length + 1); 
                files[files.Length - 1] = file;             
            }
        }

        public void Delete(object element)
        {
            if (element is File file)
            {
                files = files.Where(f => !f.Equals(file)).ToArray();  // выбирает из files все элементы, которые НЕ равны удаляемому file, и преобразует в массив
                /*File[] newFiles = new File[files.Length - 1];
                for (int i = 0; i < files.Length; i++)
                {
                    if (files[i].Equals(file))
                    {
                        continue;
                    }
                    else
                    {
                        newFiles[i] = files[i];
                    }
                }
                files = newFiles;*/
            }
        }

        public void Save(string fileName)
        {
            using (StreamWriter writer = new StreamWriter(fileName))
            {
                foreach (var file in files)
                {
                    writer.WriteLine(file.ToString()); 
                }
            }
            IsDataSaved = true; 
        }

        public void Load(string fileName)
        {
            string[] lines = System.IO.File.ReadAllLines(fileName);
            File[] loadedFiles = new File[lines.Length];

            for (int i = 0; i < lines.Length; i++)
            {
                var parts = lines[i].Split(';');
                if (parts.Length >= 3)
                {
                    string name = parts[0];
                    string authorName = parts[1];
                    DateTime date = DateTime.Parse(parts[2]);

                    Person author = new Person(authorName); 
                    loadedFiles[i] = new File(name, author, date);
                }
                else
                {
                    throw new FormatException($"Ошибка чтения строки {i + 1} из файла: недостаточно данных.");
                }
            }

            files = loadedFiles;
            IsDataSaved = true;
        }

        public bool IsDataSaved { get; set; }
        
        private int position = -1;
        public bool MoveNext()
        {
            position++;
            return position < files.Length;
        }

        public void Reset()
        {
            position = -1;
        }

        public File Current => files[position];

        object IEnumerator.Current => Current;
    }
   
}
