using Task3.Models.Enums;

namespace Task3.Models;

public class Vehicle : Entity
{
    public string Model { get; }
    public double Capacity { get; }
    public double HandlingDifficulty { get; }
    public VehicleStatus VehicleStatus { get; private set; }
    
    public Vehicle(int id, string model, double capacity, double handlingDifficulty) : base(id)
    {
        ArgumentException.ThrowIfNullOrWhiteSpace(model);
        if (capacity <= 0) throw new ArgumentOutOfRangeException(nameof(capacity), "Вантажопідйомність повинна бути більшою за нуль.");
        if (handlingDifficulty <= 0) throw new ArgumentOutOfRangeException(nameof(handlingDifficulty), "Коефіцієнт складності повинен бути більшим за нуль.");
        
        Model = model;
        Capacity = capacity;
        HandlingDifficulty = handlingDifficulty;
        VehicleStatus = VehicleStatus.Available;
    }
    public void BreakDown()
    {
        VehicleStatus = VehicleStatus.Broken;
    }
    public void SendToRepair()
    {
        VehicleStatus = VehicleStatus.InRepair;
    }
    public void Release()
    {
        if (VehicleStatus != VehicleStatus.OnTrip)
        {
            throw new InvalidOperationException($"Неможливо звільнити автомобіль: він перебуває у статусі '{VehicleStatus}', а не 'OnTrip'.");
        }

        VehicleStatus = VehicleStatus.Available;
    }
    public void CompleteRepair()
    {
        if (VehicleStatus != VehicleStatus.InRepair)
        {
            throw new InvalidOperationException($"Неможливо завершити ремонт: автомобіль перебуває у статусі '{VehicleStatus}', а не 'InRepair'.");
        }

        VehicleStatus = VehicleStatus.Available;
    }
    public void StartTrip()
    {
        if (VehicleStatus != VehicleStatus.Available)
        {
            throw new InvalidOperationException($"Автомобіль не може вийти в рейс зі статусу '{VehicleStatus}'.");
        }

        VehicleStatus = VehicleStatus.OnTrip;
    }
}