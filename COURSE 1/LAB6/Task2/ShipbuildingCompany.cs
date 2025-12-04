namespace Task2
{
// Наследник от Organization
    public class ShipbuildingCompany(string nameOfOrganization, int amountOfWorkers, int amountOfEngineers)
        : Organization(nameOfOrganization, amountOfWorkers, amountOfEngineers)
    {
        
        
        
        
        public override string ToString()
        {
            return $"Название организации: {NameOfOrganization}\n" +
                   $"Количество работников в судостроительной компании: {AmountOfWorkers}\n" +
                   $"Количество инженеров в судостроительной компании:  {AmountOfEngineers}";
        }
    }
}