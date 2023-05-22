using FuelConsumptionApp.Contracts;
using FuelConsumptionApp.Entities;
using Microsoft.EntityFrameworkCore;

namespace FuelConsumptionApp.Infra.Data.Seeders
{
    internal static class FuelConsumptionSeeder
    {
        private static readonly List<FuelConsumption> _cars = new ();
        private static IFuelConsumptionRepository? _repository;

        internal static async Task Seed(IFuelConsumptionRepository repository)
        {
            if (repository is null)
                return;

            _repository = repository;

            _cars.Clear();

            await RecordingCarHandler(50, "Ana");
            await RecordingCarHandler(55, "Otavio");
            await RecordingCarHandler(40, "Marcos");

            if (_cars.Any())
                await _repository.Insert(_cars);
        }

        private static async Task RecordingCarHandler(int capacity, string owner)
        {
            var alreadyRecorded = await VerifyIsAlreadyRecorded(capacity, owner);

            if (alreadyRecorded)
                return;

            _cars.Add(new FuelConsumption(capacity, owner));
        }

        private static async Task<bool> VerifyIsAlreadyRecorded(int capacity, string owner)
        {
            if (_repository is null)
                return true;

            return await _repository
                .Query()
                .Where(fc => fc.Capacity == capacity && fc.Owner == owner)
                .AnyAsync();
        }
    }
}
