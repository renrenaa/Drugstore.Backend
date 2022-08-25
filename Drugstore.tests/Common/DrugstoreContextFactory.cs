using Drugstore.Domain;
using Microsoft.EntityFrameworkCore;
using Persistance;

namespace Drugstore.Tests.Common
{
    public static class DrugstoreContextFactory
    {
        public static Guid DrugIdForCreate = Guid.NewGuid();
        public static Guid DrugIdForDelete = Guid.NewGuid();
        public static Guid DrugIdForUpdate = Guid.NewGuid();

        public static DrugstoreDbContext Create()
        {
            var options = new DbContextOptionsBuilder<DrugstoreDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;
            var context = new DrugstoreDbContext(options);  
            context.Database.EnsureCreated();
            context.Drugs.AddRange(
                new Drug
                {
                    Id = Guid.Parse("0F45976E-DADB-44CE-AA52-F7F188B66D08"),
                    Price = 145.00m,
                    Tittle = "Tittle1",
                    Quantity = 25,
                    Description = "descriprion1",
                    IsOnPrescription = true,
                },
                new Drug
                {
                    Id = DrugIdForDelete,
                    Price = 145.00m,
                    Tittle = "Tittle2",
                    Quantity = 25,
                    Description = "descriprion2",
                    IsOnPrescription = true,
                },
                new Drug
                {
                    Id = DrugIdForUpdate,
                    Price = 145.00m,
                    Tittle = "Tittle3",
                    Quantity = 25,
                    Description = "descriprion3",
                    IsOnPrescription = true,
                }); 
            context.SaveChanges();
            return context;
        }

        public static void Destroy(DrugstoreDbContext context)
        {
            context.Database.EnsureDeleted();
            context.Dispose();
        }
    }
}
