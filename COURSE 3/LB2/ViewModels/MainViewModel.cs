using System.Collections.ObjectModel;
using System.Windows.Input;
using Task1.Models;
using Task1.Models.Game;
using Task1.Models.Units;
using Task1.ViewModels.Base;

namespace Task1.ViewModels;

public class MainViewModel : ObservableObject
{
    private readonly GameSession _session = new();

    public ObservableCollection<CellViewModel> Cells { get; } = new();
    public ObservableCollection<string> GameLogs { get; } = new();

    public string CurrentTurnInfo =>
        _session.CurrentTurnClan != null
            ? $"Хід: {_session.CurrentTurnClan.Name} (Раунд {_session.TurnNumber})"
            : "Гра не розпочата";

    public string SelectedUnitInfo
    {
        get
        {
            var u = _session.SelectedUnit;
            if (u == null)
            {
                return "Боєць не вибраний.\nКлікніть по бійцю свого клану на дошці.";
            }

            string emoji = u.Race switch
            {
                "Воїн" => "⚔️",
                "Ельф" => "🏹",
                "Гном" => "🔨",
                _ => "👤"
            };

            if (u == ClanLeader.Instance?.Unit)
            {
                emoji = "👑" + emoji;
            }

            return $"{emoji} {u.Name}\n" +
                   $"Раса: {u.Race} | Клан: {u.ClanName}\n" +
                   $"❤️ Здоров'я: {u.CurrentHealth}/{u.MaxHealth}\n" +
                   $"⚡ Очки Дії: {u.CurrentAp}/{u.MaxAp}\n" +
                   $"📍 Позиція: ({u.Position.X}, {u.Position.Y})\n" +
                   $"🗡 Зброя: {u.Weapon.Name} (Шкода {u.Weapon.MinDamage}-{u.Weapon.MaxDamage}, Дальність {u.Weapon.Range}, Вартість {u.Weapon.ApCost} ОД)\n" +
                   $"👟 Пересування: {u.MovingStrategy.Name} (1 хід)";
        }
    }

    public string LeaderInfo
    {
        get
        {
            var leader = ClanLeader.Instance;
            if (leader == null || leader.Unit == null)
            {
                return "Главу клану ще не обрано.";
            }

            var u = leader.Unit;
            string emoji = u.Race switch
            {
                "Воїн" => "⚔️",
                "Ельф" => "🏹",
                "Гном" => "🔨",
                _ => "👤"
            };

            var enemyLeader = _session.EnemyClan?.Leader;
            string enemyEmoji = enemyLeader != null
                ? (enemyLeader.Race switch
                {
                    "Воїн" => "⚔️",
                    "Ельф" => "🏹",
                    "Гном" => "🔨",
                    _ => "👤"
                })
                : "👤";

            string enemyInfo = enemyLeader != null
                ? $"\n\n★ 👑 Лідер Червоних ★\n" +
                  $"Ім'я: {enemyEmoji} {enemyLeader.Name} ({enemyLeader.Race})\n" +
                  $"❤️ Здоров'я: {enemyLeader.CurrentHealth}/{enemyLeader.MaxHealth}\n" +
                  $"⚡ Очки Дії: {enemyLeader.CurrentAp}/{enemyLeader.MaxAp}\n" +
                  $"📍 Координати: ({enemyLeader.Position.X}, {enemyLeader.Position.Y})\n" +
                  $"🗡 Зброя: {enemyLeader.Weapon.Name} (Шкода {enemyLeader.Weapon.MinDamage}-{enemyLeader.Weapon.MaxDamage})\n" +
                  $"Статус: {(enemyLeader.IsAlive ? "Живий і командує" : "Полеглий у бою")}"
                : "";

            return $"★ 👑 Лідер Синіх ★\n" +
                   $"Ім'я: {emoji} {u.Name} ({u.Race})\n" +
                   $"❤️ Здоров'я: {u.CurrentHealth}/{u.MaxHealth}\n" +
                   $"⚡ Очки Дії: {u.CurrentAp}/{u.MaxAp}\n" +
                   $"📍 Координати: ({u.Position.X}, {u.Position.Y})\n" +
                   $"🗡 Зброя: {u.Weapon.Name} (Шкода {u.Weapon.MinDamage}-{u.Weapon.MaxDamage})\n" +
                   $"Статус: {(u.IsAlive ? "Живий і командує" : "Полеглий у бою")}" +
                   enemyInfo;
        }
    }

    public ICommand NewGameCommand { get; }
    public ICommand EndTurnCommand { get; }
    public ICommand MoveUpCommand { get; }
    public ICommand MoveDownCommand { get; }
    public ICommand MoveLeftCommand { get; }
    public ICommand MoveRightCommand { get; }

    public MainViewModel()
    {
        // Підписка на додавання записів у лог
        _session.LogAdded += msg => GameLogs.Insert(0, msg);
        
        for (int y = 0; y < 10; y++)
        {
            for (int x = 0; x < 10; x++)
            {
                Cells.Add(new CellViewModel(new Position(x, y), OnCellClicked));
            }
        }

        // Ініціалізація команд
        NewGameCommand = new RelayCommand(_ => StartNewGame());
        EndTurnCommand = new RelayCommand(_ =>
        {
            _session.EndTurn();
            RefreshBoard();
        }, _ => _session.CurrentTurnClan != null);

        MoveUpCommand = new RelayCommand(_ => MoveSelected(0, -1), _ => CanMoveSelected());
        MoveDownCommand = new RelayCommand(_ => MoveSelected(0, 1), _ => CanMoveSelected());
        MoveLeftCommand = new RelayCommand(_ => MoveSelected(-1, 0), _ => CanMoveSelected());
        MoveRightCommand = new RelayCommand(_ => MoveSelected(1, 0), _ => CanMoveSelected());

        // Запуск першої партії
        StartNewGame();
    }

    private void StartNewGame()
    {
        GameLogs.Clear();
        _session.StartNewGame();
        RefreshBoard();
    }

    private bool CanMoveSelected()
    {
        return _session.SelectedUnit != null
               && _session.SelectedUnit.ClanName == _session.CurrentTurnClan?.Name;
    }

    private void MoveSelected(int dx, int dy)
    {
        if (_session.SelectedUnit == null) return;

        var pos = _session.SelectedUnit.Position;
        var targetPos = new Position(pos.X + dx, pos.Y + dy);

        _session.TryMoveSelectedUnit(targetPos, out _);
        RefreshBoard();
    }

    private void OnCellClicked(CellViewModel cell)
    {
        if (cell.Unit != null)
        {

            if (cell.Unit.ClanName == _session.CurrentTurnClan?.Name)
            {
                _session.SelectedUnit = cell.Unit;
            }

            else if (_session.SelectedUnit != null)
            {
                _session.TryAttack(cell.Unit, out _);
            }
        }
        else
        {

            if (_session.SelectedUnit != null)
            {
                _session.TryMoveSelectedUnit(cell.Position, out _);
            }
        }

        RefreshBoard();
    }

    private void RefreshBoard()
    {
        var selected = _session.SelectedUnit;
        bool isCurrentClanUnit = selected != null && selected.ClanName == _session.CurrentTurnClan?.Name;

        foreach (var cell in Cells)
        {
            var unit = _session.GetUnit(cell.Position);
            cell.Unit = unit;
            cell.IsSelected = (unit != null && unit == selected);

            if (isCurrentClanUnit && selected != null)
            {
                // Чи доступна порожня клітинка для переміщення
                cell.IsReachable = (unit == null && selected.CanMoveTo(cell.Position));
                // Чи доступний ворог для атаки зброєю
                cell.IsTargetable = (unit != null && selected.CanAttack(unit));
            }
            else
            {
                cell.IsReachable = false;
                cell.IsTargetable = false;
            }

            cell.Refresh();
        }

        OnPropertyChanged(nameof(CurrentTurnInfo));
        OnPropertyChanged(nameof(SelectedUnitInfo));
        OnPropertyChanged(nameof(LeaderInfo));
    }
}
