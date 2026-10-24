using Task1.Models.Interfaces;

namespace Task1.Models.Movement;

public class LightMovement : IMovingStrategy
{
    public string Name { get; } = "Біг";
    public bool CanMove(Position positionFrom, Position positionTo)
    {
        int dist = positionFrom.DistanceTo(positionTo);
        return dist >= 1 && dist <= 2;
    }

    public int GetApCost(Position positionFrom, Position positionTo)
    {
        return 1;
    }
}