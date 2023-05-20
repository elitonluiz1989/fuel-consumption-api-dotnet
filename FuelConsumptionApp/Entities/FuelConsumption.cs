namespace FuelConsumptionApp.Entities
{
    public class FuelConsumption
    {
        public int SerialNumber { get; private set; }
        public int Capacity { get; private set; }
        public string Owner { get; private set; }

        public bool IsRecorded => SerialNumber > 0;

        public FuelConsumption(
            int capacity,
            string owner
        )
        {
            Capacity = capacity;
            Owner = owner;
        }
    }
}
