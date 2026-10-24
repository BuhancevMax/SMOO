using Task1.Models.Interfaces;
using Task1.Models.Movement;
using Task1.Models.Units;
using Task1.Models.Weapons;

namespace Task1.Models.Factories;

public class WarriorFactory : IUnitFactory
{
    public IWeapon CreateWeapon()
    {
        return new Sword();
    }

    public IMovingStrategy CreateMovingStrategy()
    {
        return new MediumMovement();
    }

    public IUnit CreateUnit(string name, Position position, string clanName)
    {
        return new Warrior(name, position, clanName, CreateWeapon(), CreateMovingStrategy());
    }
}