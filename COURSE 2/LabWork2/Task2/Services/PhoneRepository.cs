using Task2.Models;

namespace Task2;

    public class PhoneRepository
    {
        private List<Phone> _phones;

        public PhoneRepository()
        {
            _phones = new List<Phone>
            {
                new Phone("iPhone 15 Pro", "Apple", 42000, new DateTime(2023, 9, 22)),
                new Phone("Galaxy S24 Ultra", "Samsung", 38500, new DateTime(2024, 1, 30)),
                new Phone("Pixel 8", "Google", 25000, new DateTime(2023, 10, 4)),
                new Phone("Redmi Note 13", "Xiaomi", 8500, new DateTime(2024, 1, 15)),
                new Phone("iPhone SE", "Apple", 15000, new DateTime(2022, 3, 18)),
                new Phone("Galaxy A55", "Samsung", 14000, new DateTime(2024, 3, 11)),
                new Phone("Pixel 7a", "Google", 16500, new DateTime(2023, 5, 10)),
                new Phone("Xiaomi 14", "Xiaomi", 29000, new DateTime(2023, 12, 1)),
                new Phone("Nokia 3310 (2017)", "Nokia", 2500, new DateTime(2017, 5, 24))
            };
        }

        public IEnumerable<Phone> GetAll() => _phones;

    } 


