using Task3.Models;

namespace Task3.Services.Interfaces;

public interface IDriverSelector
{
    Driver? SelectDriver(IEnumerable<Driver> availableDrivers, Order order, Vehicle vehicle);
}