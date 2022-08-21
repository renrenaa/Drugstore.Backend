namespace Persistance
{
    public class DbInitializer
    {
        public DbInitializer(DrugstoreDbContext context)
        {
            context.Database.EnsureCreated();
        }
    }
}
