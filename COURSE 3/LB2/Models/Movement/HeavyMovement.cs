using Task1.Models.Interfaces;

namespace Task1.Models.Movement;

public class HeavyMovement : IMovingStrategy
{
    public string Name { get; } = "Важка хода";
    public bool CanMove(Position positionFrom, Position positionTo)
    {
        return positionFrom.ManhattanDistanceTo(positionTo) == 1;
    }

    public int GetApCost(Position positionFrom, Position positionTo)
    {
        return 2;
    }
}