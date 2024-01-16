using LokApp.Entities;
namespace LokApp.Data
{
    using Microsoft.EntityFrameworkCore;
    public class TrainAppDbContext : DbContext
    {
        public DbSet<Train> Trains => Set<Train>();

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseInMemoryDatabase("StorageAppDb");
        }
    }
}
