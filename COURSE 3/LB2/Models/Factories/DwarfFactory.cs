using Task1.Models.Interfaces;
using Task1.Models.Movement;
using Task1.Models.Units;
using Task1.Models.Weapons;

namespace Task1.Models.Factories;

public class DwarfFactory : IUnitFactory
{
    public IWeapon CreateWeapon()
    {
        return new Warhammer();
    }

    public IMovingStrategy CreateMovingStrategy()
    {
        return new HeavyMovement();
    }

    public IUnit CreateUnit(string name, Position position, string clanName)
    {
        return new Dwarf(name, position, clanName, CreateWeapon(), CreateMovingStrategy());
    }
}