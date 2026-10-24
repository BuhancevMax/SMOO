using Task1.Models.Interfaces;

namespace Task1.Models.Units;

public class Dwarf : UnitBase
{
    public Dwarf(string name, Position position, string clanName, IWeapon weapon, IMovingStrategy movingStrategy)
        : base(name, "Гном", clanName, position, maxHealth: 130, maxAp: 6, weapon, movingStrategy){}

    public override IUnit Clone()
    {
        return new Dwarf(Name, Position, ClanName, Weapon, MovingStrategy)
        {
            CurrentHealth = CurrentHealth,
            CurrentAp = CurrentAp
        };
    }
}