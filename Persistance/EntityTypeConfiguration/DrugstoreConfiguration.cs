using Drugstore.Domain;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Persistance.EntityTypeConfiguration
{
    internal class DrugstoreConfiguration : IEntityTypeConfiguration<Drug>
    {
        public void Configure(EntityTypeBuilder<Drug> builder)
        {
            builder.HasKey(drug => drug.Id);
            builder.HasIndex(drug => drug.Id).IsUnique();
            builder.Property(drug => drug.Tittle).HasMaxLength(50);
            builder.Property(drug => drug.Price).HasColumnType("decimal(7,2)");
        }
    }
}