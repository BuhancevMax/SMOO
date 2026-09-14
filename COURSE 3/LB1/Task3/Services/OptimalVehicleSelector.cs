using Task3.Models;
using Task3.Models.Enums;
using Task3.Services.Interfaces;

namespace Task3.Services;

public class OptimalVehicleSelector : IVehicleSelector
{
    public Vehicle? SelectVehicle(IEnumerable<Vehicle> availableVehicles, Order order)
    {
        ArgumentNullException.ThrowIfNull(availableVehicles);
        ArgumentNullException.ThrowIfNull(order);
        
        var vehicle = availableVehicles.Where(x => x.VehicleStatus == VehicleStatus.Available && x.Capacity >= order.Cargo.Weight)
            .MinBy(x => x.Capacity);
        return vehicle;
    }
}