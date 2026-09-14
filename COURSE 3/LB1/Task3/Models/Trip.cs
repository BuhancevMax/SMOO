using Task3.Models.Enums;

namespace Task3.Models;

public class Trip : Entity
{
    public Driver Driver { get; private set; }
    public Order Order { get; private set; }
    public Vehicle Vehicle { get; private set; }
    public TripStatus Status { get; private set; }
    public decimal PaymentAmount { get; private set; }
    public string? CancelReason { get; private set; }

    public Trip(int id, Driver driver, Order order, Vehicle vehicle, decimal paymentAmount) : base(id)
    {
        if (driver == null) throw new ArgumentNullException(nameof(driver), "Водій не може бути порожнім.");
        if (order == null) throw new ArgumentNullException(nameof(order), "Замовлення не може бути порожнім.");
        if (vehicle == null) throw new ArgumentNullException(nameof(vehicle), "Автомобіль не може бути порожнім.");
        if (paymentAmount < 0) throw new ArgumentOutOfRangeException(nameof(paymentAmount), "Сума платежу повинна бути більшою за нуль або дорівнювати нулю.");
        Status = TripStatus.Created;
        Driver = driver;
        Order = order;
        Vehicle = vehicle;
        PaymentAmount = paymentAmount;
    }

    public void Start()
    {
        Status = TripStatus.InProgress;
    }

    public void Complete()
    {
        Status = TripStatus.Completed;
    }

    public void Cancel(string reason)
    {
        Status = TripStatus.Cancelled;
        CancelReason = reason;
    }
}