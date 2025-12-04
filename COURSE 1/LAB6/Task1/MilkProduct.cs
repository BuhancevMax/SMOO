using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task1
{
    class MilkProduct : Product
    {
        private string manufactureName;
        private double massFractionOfMilk;
        MilkProduct()
        {
            manufactureName = "Unknown manufacture";
            massFractionOfMilk = -1;
        }
        public MilkProduct(string name, DateTime dateOfRelease, DateTime dateOfUsage, double price, string manufactureName, double massFractionOfMilk) : base(name, dateOfRelease, dateOfUsage, price)
        {
            ManufactureName = manufactureName;
            MassFractionOfMilk = massFractionOfMilk;
        }
        public string ManufactureName
        {
            get { return manufactureName; }
            set { manufactureName = string.IsNullOrWhiteSpace(value) ? throw new ArgumentException("Название не может быть пустым!") : value; }
        }
        public double MassFractionOfMilk
        {
            get { return massFractionOfMilk; }
            set { massFractionOfMilk = value >= 0 ? value : throw new ArgumentException("Значение не может быть отрицательным!"); }
        }
        public override string ToString()
        {
            return base.ToString() + "\nИзготовитель: " + "\"" + manufactureName + "\"" + "\nМасовая часть молока: " + massFractionOfMilk;
        }


    }
}
