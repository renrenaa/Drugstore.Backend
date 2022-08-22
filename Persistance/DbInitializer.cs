namespace Persistance
{
    public static class DbInitializer
    {
        public static void Initialize(DrugstoreDbContext context)
            => context.Database.EnsureCreated();
    }
}
