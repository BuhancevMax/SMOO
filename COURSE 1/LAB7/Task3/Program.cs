namespace Task3;

 public class Program
 {
     public static void Main(string[] args)
     {
         string text = "aBcD";
         ACipher aCipher = new ACipher();
         BCipher bCipher = new BCipher();
     
         Console.WriteLine(bCipher.Encode(text));
         Console.WriteLine(aCipher.Encode(text));
         
     }
 }
