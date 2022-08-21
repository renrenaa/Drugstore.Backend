using Microsoft.EntityFrameworkCore;
using Drugstore.Domain;

namespace Drugstore.Application.Interfaces
{
    public interface IDrugstoreDbContext
    {
        public DbSet<Drug> Drugs { get; set; }
        Task<int> SaveChangesAsync(CancellationToken cancellationToken);
    }
}
