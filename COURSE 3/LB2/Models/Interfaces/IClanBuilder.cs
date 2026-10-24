using Task1.Models.Clans;

namespace Task1.Models.Interfaces;

public interface IClanBuilder
{
    void Reset(string clanName);
    void BuildSquad(string raceName, IUnitFactory factory, int count);
    void PositionUnits(int minRow, int maxRow, HashSet<Position> occupiedPositions, Random random);
    void AssignLeader(Random random, bool isPlayerClan);
    Clan GetClan();
}