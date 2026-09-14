using Task3.Models;
using Task3.Services;
using Task3.Services.Interfaces;
using Task3.UI;

namespace Task3;
public class Program
{
    public static void Main(string[] args)
    {
        IVehicleSelector vehicleSelector = new OptimalVehicleSelector();
        IDriverSelector driverSelector = new ExperienceDriverSelector();
        IPaymentCalculator paymentCalculator = new StandardPaymentCalculator();
        IOrderGenerator orderGenerator = new RandomOrderGenerator();
        
        var dispatcher = new Dispatcher(driverSelector, paymentCalculator, vehicleSelector);
        
        dispatcher.Vehicles.AddRange(new List<Vehicle>
        {
            new(1, "Газель Next", 1.5, 1.0),
            new(2, "Mercedes-Benz Atego", 5.0, 1.4),
            new(3, "MAN TGS", 12.0, 1.8),
            new(4, "Scania R500", 22.0, 2.2)
        });
        
        dispatcher.Drivers.AddRange(new List<Driver>
        {
            new(1, "Олександр Коваленко", 1, 0m),
            new(2, "Сергій Мельник", 3, 0m),
            new(3, "Іван Бондаренко", 6, 0m),
            new(4, "Микола Ткаченко", 10, 0m)
        });
        
        var menu = new ConsoleMenu(dispatcher, orderGenerator);
        menu.Run();
    }
}