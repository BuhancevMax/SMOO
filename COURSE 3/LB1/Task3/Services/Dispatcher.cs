using Task3.Models;
using Task3.Models.Enums;
using Task3.Services.Interfaces;

namespace Task3.Services;

public class Dispatcher 
{
    private IDriverSelector DriverSelector { get; }
    private IPaymentCalculator PaymentCalculator { get; }
    private IVehicleSelector VehicleSelector { get; }
    public List<Vehicle> Vehicles { get; } = new();
    public List<Trip> Trips { get; } = new();
    public List<Driver> Drivers { get; } = new();
    
    public Dispatcher(IDriverSelector driverSelector, IPaymentCalculator paymentCalculator, IVehicleSelector vehicleSelector)
    {
        DriverSelector = driverSelector;
        PaymentCalculator = paymentCalculator;
        VehicleSelector = vehicleSelector;
    }

    public Trip? CreateTrip(Order order)
    {
        ArgumentNullException.ThrowIfNull(order);
    
        var vehicle = VehicleSelector.SelectVehicle(Vehicles, order);
        if (vehicle is null) return null;
    
        var driver = DriverSelector.SelectDriver(Drivers, order, vehicle);
        if (driver is null) return null;
    
        var payment = PaymentCalculator.CalculatePayment(order, vehicle);
        var trip = new Trip(Trips.Count + 1, driver, order, vehicle, payment);
    
        driver.Assign();
        vehicle.StartTrip();
        trip.Start();
        Trips.Add(trip);
    
        return trip;
    }

    public void CompleteTrip(int tripId)
    {
        var trip = FindTrip(tripId);

        if (trip.Status != TripStatus.InProgress)
        {
            throw new InvalidOperationException($"Неможливо завершити рейс зі статусом {trip.Status}.");
        }
    
        trip.Driver.ReceivePayment(trip.PaymentAmount);
        trip.Driver.Release();
        trip.Vehicle.Release();
        trip.Complete();
    }
    
    public void ReportBreakDown(int tripId, string reason)
    {
        var trip = FindTrip(tripId);

        if (trip.Status != TripStatus.InProgress)
        {
            throw new InvalidOperationException($"Неможливо зафіксувати поломку для рейсу зі статусом {trip.Status}.");
        }
    
        trip.Vehicle.BreakDown();
        trip.Driver.Release();
        trip.Cancel(reason);
    }
    
    public void SendToRepair(int tripId, string reason)
    {
        var trip = FindTrip(tripId);
    
        if (trip.Status != TripStatus.InProgress)
        {
            throw new InvalidOperationException($"Неможливо відправити на ремонт рейс зі статусом {trip.Status}.");
        }

        trip.Driver.ReceivePayment(trip.PaymentAmount * 0.75m);
        trip.Driver.Release();
        trip.Vehicle.SendToRepair();
        trip.Cancel(reason);
    }
    public void CompleteVehicleRepair(int vehicleId)
    {
        var vehicle = Vehicles.FirstOrDefault(v => v.Id == vehicleId)
                      ?? throw new KeyNotFoundException($"Автомобіль з Id {vehicleId} не знайдено.");

        vehicle.CompleteRepair();
    }

    private Trip FindTrip(int tripId)
    {
        foreach (var trip in Trips)
        {
            if (trip.Id == tripId)
            {
                return trip;
            }
        }
        throw new KeyNotFoundException($"Рейс з Id {tripId} не знайдено.");
    }
}