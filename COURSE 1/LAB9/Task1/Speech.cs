namespace Task1;

public class Speech
{
    public int CountOfSpeeches { get; }
    public int CountOfUppercase { get; }
    public int CountOfLowercase { get;}
    public int CountOfNumbers { get;}
    public int CountOfVowels { get;}
    public int CountOfConsonants { get;}
    public Speech(string text)
    {
        if (text == null) return;
        string vowels = "АОУЭЫИЯЕЁЮаоуэыияеёю";
        string consonants = "БВГДЖЗЙКЛМНПРСТФХЦЧШЩбвгджзйклмнпрстфхцчшщ";

        for (int i = 0; i < text.Length; i++)
        {
            char c = text[i];
            if (c == '.' || c == '!' || c == '?') CountOfSpeeches++;

            if (char.IsUpper(c)) CountOfUppercase++;

            if (char.IsLower(c)) CountOfLowercase++;

            if (char.IsDigit(c)) CountOfNumbers++;

            if (char.IsLetter(c))
            {
                if (vowels.Contains(c)) CountOfVowels++;
                if (consonants.Contains(c)) CountOfConsonants++;
            }
        }
    }
    
    public void PrintInfo()
    {
        if (CountOfSpeeches == 0) return;
        Console.WriteLine($"Количество:\nПредложений: {CountOfSpeeches}\nЗаглавных букв: {CountOfUppercase}\n" +
                          $"Строчных букв: {CountOfLowercase}\nЦифр: {CountOfNumbers}\n" +
                          $"Гласных букв: {CountOfVowels}\nСогласных букв: {CountOfConsonants}");
    }
}