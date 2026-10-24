using Task1.Models.Interfaces;

namespace Task1.Models.Units;

public abstract class UnitBase : IUnit
{
    public abstract IUnit Clone();
    public string Name { get; set; }
    public string Race { get; }
    public string ClanName { get; }
    public bool IsLeader { get; set; }
    public Position Position { get; set; }
    public int MaxHealth { get; }
    public int CurrentHealth { get; set; }
    public int MaxAp { get; protected set; }
    public int CurrentAp { get; set; }
    public bool IsAlive => CurrentHealth > 0;
    public IWeapon Weapon { get; }
    public IMovingStrategy MovingStrategy { get; }

    public UnitBase(string name, string race, string clanName, Position position, int maxHealth, int maxAp, IWeapon weapon, IMovingStrategy movingStrategy)
    {
        ArgumentNullException.ThrowIfNull(weapon);
        ArgumentNullException.ThrowIfNull(movingStrategy);
        Name = name;
        Race = race;
        ClanName = clanName;
        Position = position;
        MaxHealth = maxHealth;
        CurrentHealth = maxHealth;
        MaxAp = maxAp;
        CurrentAp = maxAp;
        Weapon = weapon;
        MovingStrategy = movingStrategy;
    }
    
    public bool CanMoveTo(Position target)
    {
        return IsAlive
            && target.IsValid()
            && MovingStrategy.CanMove(Position, target)
            && CurrentAp >= MovingStrategy.GetApCost(Position, target);
    }

    public bool MoveTo(Position target)
    {
        if(!CanMoveTo(target)) return false;
            
        CurrentAp -= MovingStrategy.GetApCost(Position, target);
        Position = target;
        return true;
    }

    public bool CanAttack(IUnit? target)
    {
        return target != null
               && target.IsAlive
               && target.ClanName != ClanName
               && Position.DistanceTo(target.Position) <= Weapon.Range
               && CurrentAp >= Weapon.ApCost;
    }

    public int Attack(IUnit target, Random random)
    {
        if(!CanAttack(target)) return 0;
        
        CurrentAp -= Weapon.ApCost;
        int damage = Weapon.Damage(random);
        target.TakeDamage(damage);
        return damage;
    }

    public void TakeDamage(int damage)
    {
        if(damage <= 0) return;
        CurrentHealth = Math.Max(0, CurrentHealth - damage);
    }

    public void ResetAp()
    {
        CurrentAp = MaxAp;
    }

    public virtual void Demoralize()
    {
        int hpLoss = (int)Math.Round(MaxHealth * 0.30);
        CurrentHealth = Math.Max(1, CurrentHealth - hpLoss);
        MaxAp = Math.Max(1, MaxAp - 1);
        CurrentAp = Math.Max(0, CurrentAp - 1);
    }
}
