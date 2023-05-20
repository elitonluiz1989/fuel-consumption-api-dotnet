using FuelConsumptionApp.Contracts;
using FuelConsumptionApp.Infra.Data.Contexts;

namespace FuelConsumptionApp.Infra.Data.Services
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly DefaultDbContext _dbContext;

        public UnitOfWork(DefaultDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public void Commit()
        {
            _dbContext.SaveChanges();
        }
    }
}
