using Drugstore.Application.Interfaces;
using Drugstore.Domain;
using Microsoft.EntityFrameworkCore;
using Persistance.EntityTypeConfiguration;

namespace Persistance
{
    public class DrugstoreDbContext : DbContext, IDrugstoreDbContext
    {
        public DbSet<Drug> Drugs { get; set; }
        public DrugstoreDbContext(DbContextOptions<DrugstoreDbContext> options) 
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new DrugstoreConfiguration());
            modelBuilder.Entity<Drug>().Property(p => p.Price).HasColumnType("decimal(7,2)");
            base.OnModelCreating(modelBuilder);
        }
    }
}
