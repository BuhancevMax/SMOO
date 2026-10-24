using Task1.Models.Interfaces;

namespace Task1.Models.Weapons;

public class Warhammer : IWeapon
{
    public string Name { get; } = "Бойовий молот";
    public int MinDamage { get; } = 10;
    public int MaxDamage { get; } = 30;
    public int Range { get; } = 1;
    public int ApCost { get; } = 2;
    public int Damage(Random random)
    {
        return random.Next(MinDamage, MaxDamage + 1);
    }
}