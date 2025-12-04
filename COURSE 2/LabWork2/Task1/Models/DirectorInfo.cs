namespace Task1;

public record DirectorInfo(string FullName) // хранит данные строки FullName
{ 
    public string LastName => FullName.Split(' ', StringSplitOptions.RemoveEmptyEntries).LastOrDefault() ?? string.Empty; // вычисляемое свойство (БЕРЕМ ФАМИЛИЮ ИЗ ПОЛНОГО ИМЕНИ)
}