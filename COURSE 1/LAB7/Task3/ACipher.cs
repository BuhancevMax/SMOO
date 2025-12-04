using Task3.interfaces;

namespace Task3;

public class ACipher : ICipher
{
    public string Encode(string text)
    {
        string result = "";
        for (int i = 0; i < text.Length; i++)
        { 
            int k = text[i];
            result += (char)(k + 1);
        }
        return result;
    }

    public string Decode(string text)
    {
        string result = "";
        for (int i = 0; i < text.Length; i++)
        { 
            int k = text[i];
            result += (char)(k - 1);
        }
        return result;
    }
}