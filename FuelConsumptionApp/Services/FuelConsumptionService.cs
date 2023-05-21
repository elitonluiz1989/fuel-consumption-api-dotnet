using FuelConsumptionApp.Contracts;
using FuelConsumptionApp.Dtos;
using FuelConsumptionApp.Entities;

namespace FuelConsumptionApp.Services
{
    public class FuelConsumptionService : IFuelConsumptionService
    {
        private readonly INotificationService _notificationService;
        private readonly IFuelConsumptionRepository _repository;

        public FuelConsumptionService(
            INotificationService notificationService,
            IFuelConsumptionRepository repository
        )
        {
            _notificationService = notificationService;
            _repository = repository;
        }

        public async Task<IEnumerable<FuelConsumption>> List()
        {
            return await _repository.All();
        }

        public async Task<FuelConsumption?> Fuel(FuelConsumptionServiceDto dto)
        {
            if (dto is null) {
                _notificationService.AddNotification("The entered data is invalid");

                return default;
            }

            var record = await GetRecord(dto.SerialNumber);

            if (record is null || _notificationService.HasNotifications())
                return default;

            var availableCapacity = await Count(record.SerialNumber);

            if (availableCapacity == 0)
            {
                _notificationService.AddNotification($"The gas tank of the char with Serial Number {record.SerialNumber} is full");

                return default;
            }

            if (dto.Liters > availableCapacity)
            {
                _notificationService.AddNotification($"The value entered to refuel exceeds the available capacity of the car with Serial Number {record.SerialNumber}");

                return default;
            }

            var valueToRecord = record.RefueledLiters + dto.Liters;

            record.AlterRefueledLiters(valueToRecord);

            return record;
        }

        public async Task<FuelConsumption?> Run(FuelConsumptionServiceDto dto)
        {
            if (dto is null)
            {
                _notificationService.AddNotification("The entered data is invalid");

                return default;
            }

            var record = await GetRecord(dto.SerialNumber);

            if (record is null || _notificationService.HasNotifications())
                return default;

            if (record.RefueledLiters <= 0)
            {
                _notificationService.AddNotification($"There aren't refueled liters to run the car with Serial Number {record.SerialNumber}");

                return default;
            }

            var currentLitersAvailable = record.RefueledLiters - dto.Liters;

            if (currentLitersAvailable < 0)
            {
                _notificationService.AddNotification($"The entered value exceeds the refueled liters to run the car with Serial Number {record.SerialNumber}");

                return default;
            }

            record.AlterRefueledLiters(currentLitersAvailable);

            return record;
        }

        public async Task<int> Count(int serialNumber)
        {
            var record = await GetRecord(serialNumber);

            if (record is null || _notificationService.HasNotifications())
                return default;

            return record.AvailableCapacity;
        }

        private async Task<FuelConsumption?> GetRecord(int serialNumber)
        {
            var record = await _repository.Find(serialNumber);

            if (record is not null)
                return record;

            _notificationService.AddNotification("Record was not found.");

            return default;
        }
    }
}
