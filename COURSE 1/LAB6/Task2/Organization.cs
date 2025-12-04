namespace Task2
{

    public abstract class Organization
    {
        public string NameOfOrganization { get; protected set; }
        public int AmountOfWorkers { get; protected set; }
        public int AmountOfEngineers { get; protected set; }
        public Organization()
        {
            NameOfOrganization = "Unknown name";
            AmountOfWorkers = -1;
            AmountOfEngineers = -1;
        }
        public Organization(string nameOfOrganization, int amountOfWorkers, int amountOfEngineers)
        {
            NameOfOrganization = nameOfOrganization;
            AmountOfWorkers = amountOfWorkers;
            AmountOfEngineers = amountOfEngineers;
        }
        
        
    }
}