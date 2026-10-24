using Task1.Models.Interfaces;

namespace Task1.Models.Units;

public class ClanLeader
{
    private static ClanLeader? _instance;
    private static readonly object _lock = new();
    
    public IUnit Unit { get; }
    public string Title { get; }
    
    private ClanLeader(IUnit unit, string title = "Верховний Ватажок")
    {
        Unit = unit;
        Title = title;

        Unit.CurrentHealth += 50;
        Unit.CurrentAp += 2;
    }
    public static ClanLeader? Instance
    {
        get
        {
            lock (_lock)
            {
                return _instance;
            }
        }
    }
    public static ClanLeader Initialize(IUnit unit, string title = "Верховний Ватажок")
    {
        lock (_lock)
        {
            _instance = new ClanLeader(unit, title);
            return _instance;
        }
    }
    public static void Reset()
    {
        lock (_lock)
        {
            _instance = null;
        }
    }

}