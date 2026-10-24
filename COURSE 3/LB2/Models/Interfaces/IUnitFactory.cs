namespace Task1.Models.Interfaces;

public interface IUnitFactory
{
    IWeapon CreateWeapon();
    IMovingStrategy CreateMovingStrategy();
    IUnit CreateUnit(string name, Position position, string clanName);
}