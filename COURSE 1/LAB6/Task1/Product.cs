using System;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class Product
    {
        private string productName;
        private DateTime productDateOfRelease;
        private DateTime productDateOfUsage;
        private double productPrice;

        public Product()
        {
            productName = "Unknown name";
            productDateOfRelease = new DateTime(1990, 1,1);
            productDateOfUsage = new DateTime(1990, 1, 1);
            productPrice = -1;
        }

        public Product(string name, DateTime dateOfRelease, DateTime dateOfUsage, double price)
        {
            ProductName = name;
            ProductDateOfRelease = dateOfRelease;
            ProductDateOfUsage = dateOfUsage;
            ProductPrice = price;
        }
        public string ProductName
        {
            get { return productName; }
            set { productName = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Название не может быть пустым!") : value; }
        }
        public DateTime ProductDateOfRelease
        {
            get { return productDateOfRelease; }
            set { productDateOfRelease = value; }
        }
        public DateTime ProductDateOfUsage
        {
            get { return productDateOfUsage; }
            set { productDateOfUsage = value; }
        }
        public double ProductPrice
        {
            get { return productPrice; }
            set { productPrice = value >= 0 ? value : throw new ArgumentException("Цена не может быть отрицательной!"); }
        }
        virtual public bool isExpired()
        {
            return DateTime.Now > productDateOfUsage;
        }
        public override string ToString()
        {
            return "Название продукта: " + productName + "\nДата изготовления: " + productDateOfRelease.ToShortDateString() + "\nДата истечения: " + productDateOfUsage.ToShortDateString() + "\nЦена: " + productPrice;
        }
        public override bool Equals(object? obj)
        {
            if (obj == null || GetType() != obj.GetType()) return false;
            
            Product product = (Product)obj;
            return ProductName ==  product.ProductName && ProductDateOfRelease.Equals(product.ProductDateOfRelease) && ProductDateOfUsage.Equals(product.ProductDateOfUsage) && ProductPrice.Equals(product.ProductPrice);
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(ProductName, ProductDateOfRelease, ProductDateOfUsage, ProductPrice);
        }
        public static Product CreateProduct(string name, DateTime dateOfRelease, DateTime dateOfUsage, double price)
        {
            return new Product(name, dateOfRelease, dateOfUsage, price);
        }
        public static MilkProduct CreateMilkProduct(string name, DateTime dateOfRelease, DateTime dateOfUsage, double price, string manufactureName, double massFractionOfMilk)
        {
            return new MilkProduct(name,dateOfRelease,dateOfUsage,price,manufactureName,massFractionOfMilk);
        }
    }
}
