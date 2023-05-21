namespace FuelConsumptionApp.Entities
{
    public class FuelConsumption
    {
        public int SerialNumber { get; private set; }
        public int Capacity { get; private set; }
        public int RefueledLiters { get; private set; }
        public string Owner { get; private set; }

        public int AvailableCapacity => GetAvailableCapacity();
        public bool IsRecorded => SerialNumber > 0;

        public FuelConsumption(
            int capacity,
            string owner
        )
        {
            Capacity = capacity;
            Owner = owner;
        }

        public void AlterRefueledLiters(int refueledLiters)
        {
            RefueledLiters = refueledLiters;
        }

        private int GetAvailableCapacity()
        {
            var availableCapacity = Capacity - RefueledLiters;

            if (availableCapacity < 0)
                return 0;

            return availableCapacity;
        }
    }
}
