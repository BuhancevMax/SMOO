namespace Task1.Models;

public readonly record struct Position(int X, int Y)
{
    public int DistanceTo(Position other)
    {
        int deltaX = Math.Abs(X - other.X);
        int deltaY = Math.Abs(Y - other.Y);
        return Math.Max(deltaX, deltaY);
    }
    
    public int ManhattanDistanceTo(Position other)
    {
        return Math.Abs(X - other.X) + Math.Abs(Y - other.Y);
    }

    public bool IsValid(int boardSize = 10)
    {
        return X >= 0 && X < boardSize && Y >= 0 && Y < boardSize;
    }
    
    public override string ToString() => $"({X}, {Y})";
}


