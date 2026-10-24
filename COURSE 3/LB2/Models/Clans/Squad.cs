using Task1.Models.Interfaces;

namespace Task1.Models.Clans;

public class Squad
{
    public string RaceName { get; }
    public List<IUnit> Units { get; } = new();
    
    public Squad(string raceName) => RaceName = raceName;
    
    public bool IsAlive() => Units.Any(u => u.IsAlive);
    
    public void AddUnit(IUnit unit) => Units.Add(unit);
}