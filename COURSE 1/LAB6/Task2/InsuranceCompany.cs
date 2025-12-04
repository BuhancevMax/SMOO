namespace Task2
{
// Наследник от Organization
    public class InsuranceCompany(string nameOfOrganization, int amountOfWorkers, int amountOfEngineers)
        : Organization(nameOfOrganization, amountOfWorkers, amountOfEngineers)
    {
        

        public override string ToString()
        {
            return $"Название организации: {NameOfOrganization}\n" +
                   $"Количество работников в страховой компании: {AmountOfWorkers}\n" +
                   $"Количество инженеров в страховой компании:  {AmountOfEngineers}";
        }
        
    }
}