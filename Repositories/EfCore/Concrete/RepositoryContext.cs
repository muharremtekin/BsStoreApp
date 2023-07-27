using Entities.Models;
using Microsoft.EntityFrameworkCore;
using Repositories.EfCore.Config;

namespace Repositories.EfCore.Concrete
{
    public class RepositoryContext : DbContext
    {
        public RepositoryContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {

        }
        public DbSet<Product> Products { get; set; }
        public DbSet<Fault> Faults { get; set; }
        public DbSet<Image> Images { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ProductConfig());
            modelBuilder.ApplyConfiguration(new FaultConfig());
            modelBuilder.ApplyConfiguration(new ImageConfig());
        }
    }
}
