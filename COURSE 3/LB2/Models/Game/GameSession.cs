using Task1.Models.Builders;
using Task1.Models.Clans;
using Task1.Models.Factories;
using Task1.Models.Interfaces;
using Task1.Models.Units;

namespace Task1.Models.Game;

public class GameSession
{
    public Clan? PlayerClan { get; private set; }
    public Clan? EnemyClan { get; private set; }
    public Clan? CurrentTurnClan { get; private set; }
    
    public IUnit? SelectedUnit { get; set; }
    public int TurnNumber { get; private set; } = 1;
    
    public List<string> Logs { get; } = new();
    public event Action<string>? LogAdded;
    private readonly Random _random = new();

    private void AddLog(string message)
    {
        Logs.Add(message);
        LogAdded?.Invoke(message);
    }
    public IEnumerable<IUnit> AllAliveUnits => PlayerClan!.AllUnits
        .Concat(EnemyClan!.AllUnits)
        .Where(u => u.IsAlive);
    
    public IUnit? GetUnit(Position pos) => AllAliveUnits.FirstOrDefault(u => u.Position == pos);

    public void StartNewGame()
    {
        Logs.Clear();
        ClanLeader.Reset();

        IUnitFactory warriorFactory = new WarriorFactory();
        IUnitFactory elfFactory = new ElfFactory();
        IUnitFactory dwarfFactory = new DwarfFactory();
        IClanBuilder clanBuilder = new ClanBuilder();
        ClanDirector director = new ClanDirector();

        HashSet<Position> occupied = new();

        PlayerClan = director.ConstructClan(clanBuilder, "Сині",
            0, 1, true, occupied, _random, warriorFactory, elfFactory, dwarfFactory);
        
        EnemyClan = director.ConstructClan(clanBuilder, "Червоні",
            8, 9, false, occupied, _random, warriorFactory, elfFactory, dwarfFactory);

        CurrentTurnClan = PlayerClan;
        SelectedUnit = null;
        TurnNumber = 1;

        AddLog($"Гра почалася! Першим ходить клан \"{PlayerClan.Name}\"");
    }

    public bool TryMoveSelectedUnit(Position targetPos, out string error)
    {
        if (SelectedUnit == null)
        {
            error = "Спочатку оберіть бійця!";
            return false;
        }
        if (SelectedUnit.ClanName != CurrentTurnClan?.Name)
        {
            error = "Зараз хід іншого клану!";
            return false;
        }
        if (GetUnit(targetPos) != null)
        {
            error = "Ця клітинка вже зайнята іншим бійцем!";
            return false;
        }
        if (!SelectedUnit.CanMoveTo(targetPos))
        {
            error = "Недостатньо ОД або хід неприпустимий для цієї раси!";
            return false;
        }
        
        SelectedUnit.MoveTo(targetPos);
        AddLog($"{SelectedUnit.Name} перемістився на клітинку {targetPos}. Залишилося ОД: {SelectedUnit.CurrentAp}");
        error = string.Empty;
        return true;
    }

    public bool TryAttack(IUnit target, out string error)
    {
        if (SelectedUnit == null)
        {
            error = "Спочатку оберіть бійця!";
            return false;
        }
        if (SelectedUnit.ClanName != CurrentTurnClan?.Name)
        {
            error = "Зараз хід іншого клану!";
            return false;
        }

        if (target.ClanName == SelectedUnit.ClanName)
        {
            error = "Не можна атакувати союзників!";
            return false;
        }

        if (!SelectedUnit.CanAttack(target))
        {
            error = "Ціль поза зоною досяжності зброї або не вистачає ОД!";
            return false;
        }
        
        int damage = SelectedUnit.Attack(target, _random);
        string message = $"{SelectedUnit.Name} атакував {target.Name} і завдав {damage} шкоди!";
        if (!target.IsAlive)
        {
            message += $" {target.Name} загинув у бою!";

            var targetClan = target.ClanName == PlayerClan?.Name ? PlayerClan : EnemyClan;
            if (targetClan != null && target == targetClan.Leader && !targetClan.IsDemoralized)
            {
                targetClan.IsDemoralized = true;
                targetClan.DemoralizeClan();
                AddLog($"⚠️ УВАГА! Глава клану \"{targetClan.Name}\" ({target.Name}) загинув! Усі вижилі бійці клану деморалізовані: втратили 30% HP та 1 ОД!");
            }
        }
        AddLog(message);

        if (EnemyClan!.IsDefeated)
        {
            AddLog($"Перемога! {PlayerClan!.Name} повністю знищив супротивника!");
        }
        else if (PlayerClan!.IsDefeated)
        {
            AddLog($"Поразка! {EnemyClan!.Name} переміг!");
        }
        error = string.Empty;
        return true;
    }

    public void EndTurn()
    {
        foreach (var unit in CurrentTurnClan!.AllUnits)
        {
            unit.ResetAp();
        }
        CurrentTurnClan = (CurrentTurnClan == PlayerClan) ? EnemyClan : PlayerClan;
        if (CurrentTurnClan == PlayerClan) TurnNumber++;
        SelectedUnit = null;
        AddLog($"--- Раунд {TurnNumber}. Хід клану: \"{CurrentTurnClan!.Name}\" ---");
    }
}
