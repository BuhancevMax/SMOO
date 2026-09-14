using Task3.Models;
using Task3.Services.Interfaces;

namespace Task3.Services;

public class StandardPaymentCalculator : IPaymentCalculator
{
    public decimal CalculatePayment(Order order, Vehicle vehicle)
    {
        ArgumentNullException.ThrowIfNull(vehicle);
        ArgumentNullException.ThrowIfNull(order);
        
        const decimal baseRate = 15m;
        decimal result = baseRate*(decimal)order.Distance*(decimal)vehicle.HandlingDifficulty;
        
        return Math.Round(result, 2);
    }
}