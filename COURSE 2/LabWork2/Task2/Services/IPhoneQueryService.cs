using Task2.Models;

namespace Task2;

public interface IPhoneQueryService
{
    int GetTotalCount();
    decimal GetMinPrice();
    decimal GetMaxPrice();
    decimal GetAveragePrice();
    IEnumerable<IGrouping<string, Phone>> GroupByManufacturer();
    IEnumerable<IGrouping<int, Phone>> GroupByYear();
    string GetManufacturerWithMostPhones();
    string GetCheapestPhoneInfo();
}