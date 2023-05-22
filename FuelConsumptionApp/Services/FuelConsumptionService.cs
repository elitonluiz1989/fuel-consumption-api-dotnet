using FuelConsumptionApp.Contracts;
using FuelConsumptionApp.Dtos;
using FuelConsumptionApp.Entities;
using FuelConsumptionApp.Resources;

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
                _notificationService.AddNotification(StringResource.InvalidData);

                return default;
            }

            var record = await GetCar(dto.SerialNumber);

            if (record is null || _notificationService.HasNotifications())
                return default;

            var availableCapacity = await Count(record.SerialNumber);

            if (availableCapacity == 0)
            {
                _notificationService.AddNotification(string.Format(StringResource.TankIsFull, record.SerialNumber));

                return default;
            }

            if (dto.Liters > availableCapacity)
            {
                _notificationService.AddNotification(string.Format(StringResource.RefuelExceedsCapacity, record.SerialNumber));

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
                _notificationService.AddNotification(StringResource.InvalidData);

                return default;
            }

            var record = await GetCar(dto.SerialNumber);

            if (record is null || _notificationService.HasNotifications())
                return default;

            if (record.RefueledLiters <= 0)
            {
                _notificationService.AddNotification(string.Format(StringResource.TankIsEmpty, record.SerialNumber));

                return default;
            }

            var currentLitersAvailable = record.RefueledLiters - dto.Liters;

            if (currentLitersAvailable < 0)
            {
                _notificationService.AddNotification(string.Format(StringResource.ThereAreNotEnoughLitersToRun, record.SerialNumber));

                return default;
            }

            record.AlterRefueledLiters(currentLitersAvailable);

            return record;
        }

        public async Task<int> Count(int serialNumber)
        {
            var record = await GetCar(serialNumber);

            if (record is null || _notificationService.HasNotifications())
                return default;

            return record.AvailableCapacity;
        }

        private async Task<FuelConsumption?> GetCar(int serialNumber)
        {
            var record = await _repository.Find(serialNumber);

            if (record is not null)
                return record;

            _notificationService.AddNotification(string.Format(StringResource.CarWasNotFound, serialNumber));

            return default;
        }
    }
}
