using Task1.Models.Interfaces;

namespace Task1.Models.Units;

public class Warrior : UnitBase
{
    public Warrior(string name, Position position, string clanName, IWeapon weapon, IMovingStrategy movingStrategy)
        : base(name, "Воїн", clanName, position, maxHealth: 100, maxAp: 5, weapon, movingStrategy){}

    public override IUnit Clone()
    {
        return new Warrior(Name, Position, ClanName, Weapon, MovingStrategy)
        {
            CurrentHealth = CurrentHealth,
            CurrentAp = CurrentAp
        };
    }
}