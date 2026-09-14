using Task3.Models;

namespace Task3.Services.Interfaces;

public interface IPaymentCalculator
{
    decimal CalculatePayment(Order order, Vehicle vehicle);
}