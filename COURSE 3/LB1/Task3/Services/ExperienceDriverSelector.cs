using Task3.Models;
using Task3.Models.Enums;
using Task3.Services.Interfaces;

namespace Task3.Services;

public class ExperienceDriverSelector : IDriverSelector
{
    public Driver? SelectDriver(IEnumerable<Driver> availableDrivers, Order order, Vehicle vehicle)
    {
        ArgumentNullException.ThrowIfNull(availableDrivers);
        ArgumentNullException.ThrowIfNull(order);
        ArgumentNullException.ThrowIfNull(vehicle);
        
        int requiredExp = CalculateRequiredExperience(order, vehicle);
        var driver = availableDrivers.Where(x => x.IsAvailable && x.ExperienceYears >= requiredExp)
            .MinBy(x => x.ExperienceYears);

        return driver;
    }
    private int CalculateRequiredExperience(Order order, Vehicle vehicle)
    {
        int cargoExp = order.Cargo.Type switch
        {
            CargoType.Hazardous => 5, 
            CargoType.Fragile => 3,   
            CargoType.Perishable => 1,
            _ => 0                    
        };

        int difficultyExp = vehicle.HandlingDifficulty switch
        {
            >= 2.0 => 2,
            >= 1.5 => 1,
            _ => 0
        };

        int distanceExp = order.Distance switch
        {
            >= 800 => 2,
            >= 400 => 1,
            _ => 0
        };
        
        return cargoExp + difficultyExp + distanceExp;
    }
}