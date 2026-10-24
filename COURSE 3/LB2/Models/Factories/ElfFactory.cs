using Task1.Models.Interfaces;
using Task1.Models.Movement;
using Task1.Models.Units;
using Task1.Models.Weapons;

namespace Task1.Models.Factories;

public class ElfFactory : IUnitFactory
{
    public IWeapon CreateWeapon()
    {
        return new Bow();
    }

    public IMovingStrategy CreateMovingStrategy()
    {
        return new LightMovement();
    }

    public IUnit CreateUnit(string name, Position position, string clanName)
    {
        return new Elf(name, position, clanName, CreateWeapon(), CreateMovingStrategy());
    }
}