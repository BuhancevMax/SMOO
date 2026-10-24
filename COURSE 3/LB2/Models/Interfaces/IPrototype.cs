namespace Task1.Models.Interfaces;

public interface IPrototype<out T>
{
    T Clone();
}