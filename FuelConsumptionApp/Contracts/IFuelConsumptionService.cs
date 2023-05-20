namespace FuelConsumptionApp.Contracts
{
    public interface IFuelConsumptionService
    {
        Task Fuel(int serialNumber, int liters);
        Task Run(int serialNumber, int liters);
        Task Count(int serialNumber);
    }
}
