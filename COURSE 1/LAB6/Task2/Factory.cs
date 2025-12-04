namespace Task2
{
// Наследник от Organization
    public class Factory (string nameOfOrganization, int amountOfWorkers, int amountOfEngineers)
        : Organization(nameOfOrganization, amountOfWorkers, amountOfEngineers)
    {
        
        
        public override string ToString()
        {
            return $"Название организации: {NameOfOrganization}\n" +
                   $"Количество работников на заводе: {AmountOfWorkers}\n" +
                   $"Количество инженеров на заводе:  {AmountOfEngineers}";
        }
    }
}