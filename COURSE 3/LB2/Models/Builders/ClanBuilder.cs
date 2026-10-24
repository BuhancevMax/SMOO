using Task1.Models.Clans;
using Task1.Models.Interfaces;
using Task1.Models.Units;

namespace Task1.Models.Builders;

public class ClanBuilder : IClanBuilder
{
    private Clan? _clan;
    
    public void Reset(string clanName)
    {
        _clan = new Clan(clanName);
    }

    public void BuildSquad(string raceName, IUnitFactory factory, int count)
    {
        Squad squad = new Squad(raceName);
        IUnit prototype = factory.CreateUnit(raceName, new Position(0,0), _clan!.Name!);
        for (int i = 1; i <= count; i++)
        {
            IUnit unit = prototype.Clone();
            unit.Name = $"{raceName} {i}";
            squad.AddUnit(unit);
        }
        _clan.Squads.Add(squad);
    }

    public void PositionUnits(int minRow, int maxRow, HashSet<Position> occupiedPositions, Random random)
    {
        foreach (var unit in _clan!.AllUnits)
        {
            Position pos;
            do
            {
                int x = random.Next(0, 10); 
                int y = random.Next(minRow, maxRow + 1); 
                pos = new Position(x, y);

            } while (occupiedPositions.Contains(pos));
            
            occupiedPositions.Add(pos); 
            unit.Position = pos;        
        }
    }

    public void AssignLeader(Random random, bool isPlayerClan)
    {
        List<IUnit> units = _clan!.AllUnits.ToList();
        var leaderUnit = units[random.Next(units.Count)];
        leaderUnit.IsLeader = true;
        _clan.Leader = leaderUnit;
        
        if (isPlayerClan)
        {
            ClanLeader.Initialize(leaderUnit);
        }
        else
        {
            leaderUnit.CurrentHealth += 50;
            leaderUnit.CurrentAp += 2;
        }
    }

    public Clan GetClan()
    {
        return _clan!;
    }
}
