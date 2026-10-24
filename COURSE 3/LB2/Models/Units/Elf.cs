using Task1.Models.Interfaces;

namespace Task1.Models.Units;

public class Elf : UnitBase
{
    public Elf(string name, Position position, string clanName, IWeapon weapon, IMovingStrategy movingStrategy)
        : base(name, "Ельф", clanName, position, maxHealth: 70, maxAp: 6, weapon, movingStrategy){}

    public override IUnit Clone()
    {
        return new Elf(Name, Position, ClanName, Weapon, MovingStrategy)
        {
            CurrentHealth = CurrentHealth,
            CurrentAp = CurrentAp
        };
    }
}