
namespace Task1
{
     class Catalog : File
    {
        private string catalogName;
        private string description;
        private int sizeOfCatalog;
        private KindOf kindOfCatalog;
        private File[] files;

        public Catalog(string catalogName, string description, int sizeOfCatalog, KindOf kindOfCatalog, File[] files)
        {
            this.catalogName = catalogName;
            this.description = description;
            this.sizeOfCatalog = sizeOfCatalog;
            this.kindOfCatalog = kindOfCatalog;
            this.files = files;
        }
        public Catalog()
        {
            this.catalogName = " ";
            this.description = " ";
            this.sizeOfCatalog = 0;
            this.kindOfCatalog = KindOf.SystemPrograms;
            this.files = new File[0];
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
        public override string ToString()
        {
            string result = $"Имя каталога: {catalogName}\nОписание: {description}\nРазмер каталога: {sizeOfCatalog}\nТип каталога: {kindOfCatalog}\nФайлы в каталоге:\n\n";
            foreach (var file in files)
            {
                result += file.ToString() + "\n";
            }
            return result;
        }
        public string ToShortString()
        {
            return $"Имя каталога: {catalogName}\nТип каталога: {kindOfCatalog}\n";
        }
        public File LatestFile
        {
            get
            {
                if (files.Length == 0) return null;
                File latest = files[0];
                foreach (var file in files)
                {
                    if (file.dateOfLastEditing > latest.dateOfLastEditing)
                    {
                        latest = file;
                    }
                }
                return latest;
            }
        }
        public bool this[KindOf index]
        {
            get { return kindOfCatalog == index ? true : false; }
        }
        public void AddFiles(params File[] newFile)
        {
            if (newFile.Length == 0)
            {
                Console.WriteLine("Нет файлов для добавления.");
                return;
            }
            int oldLength = files.Length;
            Array.Resize(ref files, oldLength + newFile.Length); // изменяем размер массива на количество новых файлов
            Array.Copy(newFile, 0, files, oldLength, newFile.Length); // копируем новые файлы в конец массива

        }
        public Catalog CreateCatalog(string nameCatalog, string descCatalog, int sizeCatalog, KindOf kind, Person author, DateTime dateTime)
        {
            
            Catalog catalog = new Catalog(nameCatalog, descCatalog, sizeCatalog, kind, files);
            AddFiles(new File(nameCatalog,author, dateTime));

            return catalog;
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
            AddFiles(file);

            return file;
        }
    }
   
}
