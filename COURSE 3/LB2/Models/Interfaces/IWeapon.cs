namespace Task1.Models.Interfaces;

public interface IWeapon
{
    string Name { get; }
    int MinDamage { get; }
    int MaxDamage { get; }
    int Range { get; }
    int ApCost { get; }
    int Damage(Random random);
}