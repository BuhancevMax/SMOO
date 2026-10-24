using Task1.Models.Interfaces;

namespace Task1.Models.Weapons;

public class Sword : IWeapon
{
    public string Name { get; } = "Меч";
    public int MinDamage { get; } = 5;
    public int MaxDamage { get; } = 20;
    public int Range { get; } = 1;
    public int ApCost { get; } = 2;
    public int Damage(Random random) 
    {
        return random.Next(MinDamage, MaxDamage + 1);
    }
}