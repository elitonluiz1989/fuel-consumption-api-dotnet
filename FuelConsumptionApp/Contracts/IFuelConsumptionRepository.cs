using FuelConsumptionApp.Entities;

namespace FuelConsumptionApp.Contracts
{
    public interface IFuelConsumptionRepository
    {
        void Insert(FuelConsumption fuelConsumption);
        Task Insert(IEnumerable<FuelConsumption> fuelConsumptions);
        void Update(FuelConsumption fuelConsumption);
        Task Delete(int serialNumber);
        void Delete(FuelConsumption fuelConsumption);
        void Delete(IEnumerable<FuelConsumption> entities);
        IQueryable<FuelConsumption> Query();
        Task<IEnumerable<FuelConsumption>> All();
        Task<FuelConsumption?> Find(int serialNumber);
        void Save(FuelConsumption fuelConsumption);
    }
}
