namespace Task1.Models.Interfaces;

public interface IMovingStrategy
{
    string Name { get; }
    bool CanMove(Position positionFrom, Position positionTo);
    int GetApCost(Position positionFrom, Position positionTo);
}