using Task2;
using Task2.Utils;

class Program
{
    public static void Main(string[] args)
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;
        var phoneRepository = new PhoneRepository();
        IPhoneQueryService phoneService = new PhoneQueryService(phoneRepository);
        PhoneHelper.DisplayAllPhoneTasks(phoneService);
    }
}