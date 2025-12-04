using Task2.Models;

namespace Task2;

public class PhoneQueryService : IPhoneQueryService
{
    private readonly IEnumerable<Phone> _phones;

        public PhoneQueryService(PhoneRepository repository)
        {
            _phones = repository.GetAll();
        }

        // 1. Посчитать количество всех телефонов
        public int GetTotalCount()
        {
            return _phones.Count();
        }

        // 2. Найти минимальную цену
        public decimal GetMinPrice()
        {
            return _phones.Min(p => p.Price);
        }

        // 3. Найти максимальную цену
        public decimal GetMaxPrice()
        {
            return _phones.Max(p => p.Price);
        }

        // 4. Найти среднюю цену
        public decimal GetAveragePrice()
        {
            return _phones.Average(p => p.Price);
        }
        

        // 5. Сгруппировать телефоны по производителю
        public IEnumerable<IGrouping<string, Phone>> GroupByManufacturer()
        {
            return _phones.GroupBy(p => p.Manufacturer).OrderBy(g => g.Key);
        }

        // 6. Сгруппировать телефоны по году выпуска
        public IEnumerable<IGrouping<int, Phone>> GroupByYear()
        {
            return _phones.GroupBy(p => p.ReleaseYear).OrderByDescending(g => g.Key);
        }

        
        // 7. Найти производителя с наибольшим количеством телефонов
        public string GetManufacturerWithMostPhones()
        {
            return _phones
                .GroupBy(p => p.Manufacturer) // Группируем по производителю
                .OrderByDescending(g => g.Count()) // Сортируем группы по размеру (самые большие сверху)
                .Select(g => g.Key) // Берем только ключ (название производителя)
                .FirstOrDefault() ?? "N/A"; // Берем первого в отсортированном списке
        }

        // 8. Найти самый дешевый телефон (модель и цена)
        public string GetCheapestPhoneInfo()
        {
            var cheapestPhone = _phones
                .OrderBy(p => p.Price) // Сортируем все телефоны по возрастанию цены
                .FirstOrDefault(); // Берем первый элемент (самый дешевый)

            if (cheapestPhone == null)
            {
                return "N/A";
            }
            
            return cheapestPhone.ToString(); 
        }
}