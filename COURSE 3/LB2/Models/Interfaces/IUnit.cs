namespace Task1.Models.Interfaces;

public interface IUnit : IPrototype<IUnit>
{
    string Name { get; set; }
    string Race { get; }
    string ClanName { get; }
    bool IsLeader { get; set; }
    Position Position { get; set; }
    int MaxHealth { get; }
    int CurrentHealth { get; set; }
    int MaxAp { get; }
    int CurrentAp { get; set; }
    bool IsAlive => CurrentHealth > 0;
    IWeapon Weapon { get; }
    IMovingStrategy MovingStrategy { get; }
    
    bool CanMoveTo(Position target);
    bool MoveTo(Position target);
    bool CanAttack(IUnit? target);
    int Attack(IUnit target, Random random);
    void TakeDamage(int damage);
    void ResetAp();
    void Demoralize();
}
