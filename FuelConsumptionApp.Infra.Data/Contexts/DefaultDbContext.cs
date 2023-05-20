using Microsoft.EntityFrameworkCore;

namespace FuelConsumptionApp.Infra.Data.Contexts
{
    public class DefaultDbContext : DbContext
    {

        public static string ConnectionString { get; set; } = string.Empty;

        public DefaultDbContext()
        {
        }

        public DefaultDbContext(DbContextOptions<DefaultDbContext> options) : base(options)
        {
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
