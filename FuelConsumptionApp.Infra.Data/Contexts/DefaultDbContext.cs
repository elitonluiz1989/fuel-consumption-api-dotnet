using FuelConsumptionApp.Contracts;
using FuelConsumptionApp.Entities;
using FuelConsumptionApp.Infra.Data.Mappings;
using FuelConsumptionApp.Infra.Data.Seeders;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace FuelConsumptionApp.Infra.Data.Contexts
{
    public class DefaultDbContext : DbContext
    {
        private static string _connectionString { get; set; } = string.Empty;

        public DefaultDbContext()
        {
        }

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        public static void Configure(IServiceCollection services, string connectionString)
        {
            _connectionString = connectionString;

            services.AddDbContext<DefaultDbContext>();
        }

        public static void InitializeDatabase(IServiceProvider provider)
        {
            var context = provider.CreateScope().ServiceProvider.GetRequiredService<DefaultDbContext>();
            context.Database.Migrate();
        }

        public static async Task Seed(IServiceProvider provider)
        {
            var scope = provider.CreateScope();
            var respoitory = scope.ServiceProvider.GetRequiredService<IFuelConsumptionRepository>();
            var unitOfWork = scope.ServiceProvider.GetRequiredService<IUnitOfWork>();

            await FuelConsumptionSeeder.Seed(respoitory);

            unitOfWork.Commit();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite(_connectionString);
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<FuelConsumption>(FuelConsumptionMapping.Confingure);

            base.OnModelCreating(modelBuilder);
        }
    }
}
