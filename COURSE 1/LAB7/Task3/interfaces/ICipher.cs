namespace Task3.interfaces;

public interface ICipher
{
    string Encode(string text);
    string Decode(string text);
}