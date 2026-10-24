using Task1.Models.Interfaces;

namespace Task1.Models.Movement;

public class MediumMovement : IMovingStrategy
{
    public string Name { get; } = "Марш";
    public bool CanMove(Position positionFrom, Position positionTo)
    {
        return positionFrom.DistanceTo(positionTo) == 1;
    }

    public int GetApCost(Position positionFrom, Position positionTo)
    {
        return 1;
    }
}