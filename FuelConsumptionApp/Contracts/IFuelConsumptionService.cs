using FuelConsumptionApp.Dtos;
using FuelConsumptionApp.Entities;

namespace FuelConsumptionApp.Contracts
{
    public interface IFuelConsumptionService
    {
        Task<IEnumerable<FuelConsumption>> List();
        Task<FuelConsumption?> Fuel(FuelConsumptionServiceDto dto);
        Task<FuelConsumption?> Run(FuelConsumptionServiceDto dto);
        Task<int> Count(int serialNumber);
    }
}
