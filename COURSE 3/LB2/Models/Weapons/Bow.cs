using Task1.Models.Interfaces;

namespace Task1.Models.Weapons;

public class Bow : IWeapon
{
    public string Name { get; } = "Лук";
    public int MinDamage { get; } = 1;
    public int MaxDamage { get; } = 20;
    public int Range { get; } = 3;
    public int ApCost { get; } = 2;
    public int Damage(Random random)
    {
        return random.Next(MinDamage, MaxDamage + 1);
    }
}