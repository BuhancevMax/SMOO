using Task3.Models.Enums;
using Task3.Services;
using Task3.Services.Interfaces;

namespace Task3.UI;

public class ConsoleMenu
{
    private readonly Dispatcher _dispatcher;
    private readonly IOrderGenerator _orderGenerator;

    public ConsoleMenu(Dispatcher dispatcher, IOrderGenerator orderGenerator)
    {
        ArgumentNullException.ThrowIfNull(dispatcher);
        ArgumentNullException.ThrowIfNull(orderGenerator);
        
        _dispatcher = dispatcher;
        _orderGenerator = orderGenerator;
    }

    public void Run()
    {
        Console.OutputEncoding = System.Text.Encoding.UTF8;

        while (true)
        {
            Console.WriteLine("\n=== СИСТЕМА УПРАВЛІННЯ АВТОБАЗОЮ ===");
            Console.WriteLine("1. Згенерувати випадкову заявку та створити рейс");
            Console.WriteLine("2. Переглянути всі рейси");
            Console.WriteLine("3. Завершити рейс");
            Console.WriteLine("4. Оформити заявку на ремонт автомобіля у рейсі");
            Console.WriteLine("5. Завершити ремонт автомобіля");
            Console.WriteLine("6. Переглянути стан автопарку та водіїв");
            Console.WriteLine("0. Вихід");
            Console.Write("Оберіть опцію: ");

            var choice = Console.ReadLine();
            Console.Clear();

            switch (choice)
            {
                case "1":
                    HandleCreateTrip();
                    break;
                case "2":
                    ShowTrips();
                    break;
                case "3":
                    HandleCompleteTrip();
                    break;
                case "4":
                    HandleSendToRepair();
                    break;
                case "5":
                    HandleCompleteRepair();
                    break;
                case "6":
                    ShowFleetAndDrivers();
                    break;
                case "0":
                    Console.WriteLine("Роботу системи завершено.");
                    return;
                default:
                    Console.WriteLine("Невідомий пункт меню. Спробуйте ще раз.");
                    break;
            }
        }
    }

    private void HandleCreateTrip()
    {
        var order = _orderGenerator.GenerateOrder();
        Console.WriteLine($"[Нова заявка #{order.Id}]");
        Console.WriteLine($"Пункт призначення: {order.Destination} | Відстань: {order.Distance} км");
        Console.WriteLine($"Вантаж: {order.Cargo.Type} | Вага: {order.Cargo.Weight} т\n");

        var trip = _dispatcher.CreateTrip(order);

        if (trip == null)
        {
            Console.WriteLine("Помилка: не вдалося створити рейс! Немає доступного авто з достатньою вантажопідйомністю або кваліфікованого вільного водія.");
            return;
        }

        Console.WriteLine($"Рейс #{trip.Id} успішно призначено!");
        Console.WriteLine($"Водій: {trip.Driver.FullName} (Стаж: {trip.Driver.ExperienceYears} р.)");
        Console.WriteLine($"Авто: {trip.Vehicle.Model} (В/п: {trip.Vehicle.Capacity} т)");
        Console.WriteLine($"Сума винагороди: {trip.PaymentAmount:F2} грн");
    }

    private void ShowTrips()
    {
        Console.WriteLine("--- СПИСОК РЕЙСІВ ---");
        if (_dispatcher.Trips.Count == 0)
        {
            Console.WriteLine("Наразі немає жодного рейсу.");
            return;
        }

        foreach (var trip in _dispatcher.Trips)
        {
            Console.WriteLine($"Рейс #{trip.Id} | Статус: {trip.Status} | До: {trip.Order.Destination}");
            Console.WriteLine($"  Водій: {trip.Driver.FullName} | Авто: {trip.Vehicle.Model} | Оплата: {trip.PaymentAmount:F2} грн");
            if (trip.Status == TripStatus.Cancelled && !string.IsNullOrWhiteSpace(trip.CancelReason))
            {
                Console.WriteLine($"  Причина скасування: {trip.CancelReason}");
            }
        }
    }

    private void HandleCompleteTrip()
    {
        int tripId = ReadInt("Введіть ID рейсу для завершення: ");
        try
        {
            _dispatcher.CompleteTrip(tripId);
            Console.WriteLine($"Рейс #{tripId} успішно завершено. Водій отримав виплату, ресурси звільнено.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    private void HandleSendToRepair()
    {
        int tripId = ReadInt("Введіть ID рейсу, на якому сталася поломка: ");
        Console.Write("Вкажіть опис поломки/причину ремонту: ");
        string reason = Console.ReadLine() ?? "Технічна несправність";

        try
        {
            _dispatcher.SendToRepair(tripId, reason);
            Console.WriteLine($"Рейс #{tripId} перервано. Автомобіль направлено на ремонт, водію нараховано компенсацію.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    private void HandleCompleteRepair()
    {
        int vehicleId = ReadInt("Введіть ID автомобіля, ремонт якого завершено: ");
        try
        {
            _dispatcher.CompleteVehicleRepair(vehicleId);
            Console.WriteLine($"Ремонт автомобіля #{vehicleId} завершено. Машина знову доступна до рейсів.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Помилка: {ex.Message}");
        }
    }

    private void ShowFleetAndDrivers()
    {
        Console.WriteLine("--- АВТОМОБІЛІ АВТОБАЗИ ---");
        foreach (var v in _dispatcher.Vehicles)
        {
            Console.WriteLine($"ID {v.Id}: {v.Model} | В/п: {v.Capacity} т | Складність: {v.HandlingDifficulty} | Стан: {v.VehicleStatus}");
        }

        Console.WriteLine("\n--- ШТАТ ВОДІЇВ ---");
        foreach (var d in _dispatcher.Drivers)
        {
            string status = d.IsAvailable ? "Вільний" : "У рейсі";
            Console.WriteLine($"ID {d.Id}: {d.FullName} | Стаж: {d.ExperienceYears} р. | Баланс: {d.Balance:F2} грн | Статус: {status}");
        }
    }

    private static int ReadInt(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int result))
            {
                return result;
            }
            Console.WriteLine("Некоректне число. Будь ласка, введіть ціле число.");
        }
    }
}