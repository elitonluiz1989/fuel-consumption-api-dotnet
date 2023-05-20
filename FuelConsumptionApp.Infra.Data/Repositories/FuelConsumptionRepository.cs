using FuelConsumptionApp.Contracts;
using FuelConsumptionApp.Entities;
using FuelConsumptionApp.Infra.Data.Contexts;
using Microsoft.EntityFrameworkCore;

namespace FuelConsumptionApp.Infra.Data.Repositories
{
    public class FuelConsumptionRepository : IFuelConsumptionRepository
    {
        protected readonly DefaultDbContext _context;

        public FuelConsumptionRepository(DefaultDbContext dbContext)
        {
            _context = dbContext;
        }

        public void Insert(FuelConsumption fuelConsumption)
        {
            _context.Set<FuelConsumption>().Add(fuelConsumption);
        }

        public async Task Insert(IEnumerable<FuelConsumption> fuelConsumptions)
        {
            await _context.Set<FuelConsumption>().AddRangeAsync(fuelConsumptions);
        }

        public void Update(FuelConsumption fuelConsumption)
        {
            DetachLocalEntity(fuelConsumption);

            _context.Entry(fuelConsumption).State = EntityState.Modified;
        }

        public async Task Delete(int serialNumber)
        {
            var fuelConsumption = await Find(serialNumber);

            if (fuelConsumption is null)
                return;

            Delete(fuelConsumption);
        }

        public void Delete(FuelConsumption fuelConsumption)
        {
            DetachLocalEntity(fuelConsumption);

            _context.Set<FuelConsumption>().Remove(fuelConsumption);
        }

        public void Delete(IEnumerable<FuelConsumption> entities)
        {
            _context.Set<FuelConsumption>().RemoveRange(entities);
        }

        public IQueryable<FuelConsumption> Query()
        {
            return _context.Set<FuelConsumption>();
        }

        public async Task<IEnumerable<FuelConsumption>> All()
        {
            return await Query().ToListAsync();
        }

        public async Task<FuelConsumption?> Find(int serialNumber)
        {
            var query = Query();

            return await query.FirstOrDefaultAsync(fc => fc.SerialNumber == serialNumber);
        }

        public void Save(FuelConsumption fuelConsumption)
        {
            if (fuelConsumption.IsRecorded)
                return;

            Insert(fuelConsumption);
        }

        private void DetachLocalEntity(FuelConsumption fuelConsumption)
        {
            var localContexFuelConsumption = _context
                .Set<FuelConsumption>()
                .Local
                .FirstOrDefault(fc => fc.SerialNumber == fuelConsumption.SerialNumber);

            if (localContexFuelConsumption is not null)
                _context.Entry(localContexFuelConsumption).State = EntityState.Detached;
        }
    }
}
