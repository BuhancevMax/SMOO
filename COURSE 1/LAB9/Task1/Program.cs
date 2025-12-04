namespace Task1;

internal class Program
{
    public static void Main()
    {
        Speech speech = new Speech(FileManager.GetTextFromFile());
        speech.PrintInfo();
    }
}