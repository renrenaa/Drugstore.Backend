using Persistance;

namespace Drugstore.tests.Common
{
    public abstract class TestCommandBase : IDisposable
    {
        protected readonly DrugstoreDbContext Context;
        public TestCommandBase()
        {
            Context = DrugstoreContextFactory.Create();
        }
        public void Dispose()
        {
            DrugstoreContextFactory.Destroy(Context);
        }
    }
}
