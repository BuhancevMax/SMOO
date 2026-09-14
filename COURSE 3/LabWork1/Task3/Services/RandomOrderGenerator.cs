using Task3.Models;
using Task3.Models.Enums;
using Task3.Services.Interfaces;

namespace Task3.Services;

public class RandomOrderGenerator : IOrderGenerator
{
    private int _currentOrderId;
    private readonly Random _random = new();
    private readonly CargoType[] _cargoTypes = Enum.GetValues<CargoType>();
    private string[] _cities = new[] { "Київ", "Львів", "Одеса", "Дніпро", "Полтава" };
    
    public Order GenerateOrder()
    {
        string destination = _cities[_random.Next(_cities.Length)];
        int distance = _random.Next(50, 1000);
        CargoType type = _cargoTypes[_random.Next(_cargoTypes.Length)];
        double weight = Math.Round(0.5 + (_random.NextDouble() * (20.0 - 0.5)), 1);

        var cargo = new Cargo(type, weight);
        
        return new Order(++_currentOrderId, destination, distance,cargo);
    }
}