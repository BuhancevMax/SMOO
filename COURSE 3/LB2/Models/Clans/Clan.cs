using Task1.Models.Interfaces;

namespace Task1.Models.Clans;

public class Clan
{
    public string? Name { get; }
    public List<Squad> Squads { get; } = new();
    public IUnit? Leader { get; set; }
    
    public Clan(string name) => Name = name;
    
    public IEnumerable<IUnit> AllUnits => Squads.SelectMany(s => s.Units);
    public bool IsDefeated => AllUnits.All(u => !u.IsAlive);
    
    public bool IsDemoralized { get; set; }
    
    public void DemoralizeClan()
    {
        foreach (var unit in AllUnits.Where(u => u.IsAlive))
        {
            unit.Demoralize();
        }
    }
}