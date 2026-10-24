using Task1.Models.Clans;
using Task1.Models.Interfaces;

namespace Task1.Models.Builders;

public class ClanDirector
{
    public Clan ConstructClan(IClanBuilder builder, string clanName, int minRow, int maxRow, bool isPlayerClan, 
        HashSet<Position> occupiedPositions, Random random, IUnitFactory warriorFactory, IUnitFactory elfFactory, IUnitFactory dwarfFactory)
    {
        builder.Reset(clanName);
        builder.BuildSquad("Воїн", warriorFactory, random.Next(2,4));
        builder.BuildSquad("Ельф", elfFactory, random.Next(2,4));
        builder.BuildSquad("Гном", dwarfFactory, random.Next(2,4));
        builder.PositionUnits(minRow, maxRow, occupiedPositions, random);
        builder.AssignLeader(random, isPlayerClan);
        return builder.GetClan();
    }
}