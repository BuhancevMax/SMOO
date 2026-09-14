using Task3.Models;

namespace Task3.Services.Interfaces;

public interface IVehicleSelector
{
    Vehicle? SelectVehicle(IEnumerable<Vehicle> availableVehicles, Order order);
}