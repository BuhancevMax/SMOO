namespace Task3.Models;

public abstract class Entity
{
    public int Id { get; }

    protected Entity(int id)
    {
        if (id <= 0) throw new ArgumentOutOfRangeException(nameof(id), "Ідентифікатор повинен бути більше нуля.");
        
        Id = id;
    }
}