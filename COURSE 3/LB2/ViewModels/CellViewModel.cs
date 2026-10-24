using System.Windows.Input;
using Task1.Models;
using Task1.Models.Interfaces;
using Task1.ViewModels.Base;

namespace Task1.ViewModels;

public class CellViewModel : ObservableObject
{
    public Position Position { get; }

    private IUnit? _unit;
    public IUnit? Unit
    {
        get => _unit;
        set => SetField(ref _unit, value);
    }

    private bool _isSelected;
    public bool IsSelected
    {
        get => _isSelected;
        set => SetField(ref _isSelected, value);
    }

    private bool _isReachable;
    public bool IsReachable
    {
        get => _isReachable;
        set => SetField(ref _isReachable, value);
    }

    private bool _isTargetable;
    public bool IsTargetable
    {
        get => _isTargetable;
        set => SetField(ref _isTargetable, value);
    }

    public string DisplayText
    {
        get
        {
            if (Unit != null)
            {
                string emoji = Unit.Race switch
                {
                    "Воїн" => "⚔️",
                    "Ельф" => "🏹",
                    "Гном" => "🔨",
                    _ => "👤"
                };

                if (Unit.IsLeader)
                {
                    emoji = "👑" + emoji;
                }

                return $"{emoji} {Unit.Name}\nHP: {Unit.CurrentHealth}";
            }

            return string.Empty;
        }
    }

    public string BackgroundColor
    {
        get
        {
            if (IsSelected) return "#FFF59D"; // Жовтий — вибраний юніт
            if (IsTargetable) return "#FFCDD2"; // Червоний відтінок — ціль для атаки
            if (IsReachable) return "#E8F5E9"; // Світло-зелений відтінок — доступна клітинка ходу

            if (Unit != null)
            {
                bool isBlue = Unit.ClanName == "Сині";
                if (Unit.IsLeader)
                {
                    return isBlue ? "#90CAF9" : "#EF9A9A"; // Насиченіший відтінок для лідерів кланів
                }

                return isBlue ? "#BBDEFB" : "#FFCDD2"; // Звичайні бійці
            }

            // Чергування шахових клітинок
            return (Position.X + Position.Y) % 2 == 0 ? "#F5F5F5" : "#E0E0E0";
        }
    }

    public string BorderColor
    {
        get
        {
            if (IsSelected) return "DarkOrange";
            if (IsTargetable) return "Crimson"; // Яскраво-червона рамка для ворогів у радіусі атаки

            if (Unit != null && Unit.IsLeader)
            {
                bool isBlue = Unit.ClanName == "Сині" || Unit.ClanName == "Синие";
                return isBlue ? "Gold" : "DarkViolet"; // Золото для Синього лідера, царський фіолетовий для Червоного
            }

            if (IsReachable) return "#66BB6A"; // Зелена рамка для доступного ходу
            return "#BDBDBD";
        }
    }

    public string ToolTipText
    {
        get
        {
            if (Unit == null)
            {
                return IsReachable
                    ? $"Клітинка ({Position.X}, {Position.Y}) — натисніть, щоб переміститися"
                    : $"Клітинка ({Position.X}, {Position.Y})";
            }

            string emoji = Unit.Race switch
            {
                "Воїн" => "⚔️",
                "Ельф" => "🏹",
                "Гном" => "🔨",
                _ => "👤"
            };

            if (Unit.IsLeader)
            {
                emoji = "👑" + emoji;
            }

            string leaderPrefix = Unit.IsLeader ? "👑 [ГЛАВА КЛАНУ] " : "";

            return $"{leaderPrefix}{emoji} {Unit.Name} ({Unit.ClanName})\n" +
                   $"Здоров'я: {Unit.CurrentHealth}/{Unit.MaxHealth}\n" +
                   $"Очки Дії: {Unit.CurrentAp}/{Unit.MaxAp}\n" +
                   $"Зброя: {Unit.Weapon.Name} (Шкода {Unit.Weapon.MinDamage}-{Unit.Weapon.MaxDamage}, Дальність {Unit.Weapon.Range})\n" +
                   $"Пересування: {Unit.MovingStrategy.Name}";
        }
    }

    public ICommand ClickCommand { get; }

    public CellViewModel(Position position, Action<CellViewModel> onClick)
    {
        Position = position;
        ClickCommand = new RelayCommand(_ => onClick(this));
    }

    public void Refresh()
    {
        OnPropertyChanged(nameof(DisplayText));
        OnPropertyChanged(nameof(BackgroundColor));
        OnPropertyChanged(nameof(BorderColor));
        OnPropertyChanged(nameof(ToolTipText));
    }
}
