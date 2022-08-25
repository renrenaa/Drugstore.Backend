using AutoMapper;
using Drugstore.Application.Interfaces;
using Drugstore.Application.Mapping;
using Persistance;

namespace Drugstore.Tests.Common
{
    public class QueryTestFixture : IDisposable
    {
        public DrugstoreDbContext Context;
        public IMapper Mapper;

        public QueryTestFixture()
        {
            Context = DrugstoreContextFactory.Create();
            var configurationProvider = new MapperConfiguration(cfg =>
            {
                cfg.AddProfile(new AssemblyMappingProfile(
                    typeof(IDrugstoreDbContext).Assembly));
            });
            Mapper = configurationProvider.CreateMapper();
        }
        public void Dispose()
        {
            DrugstoreContextFactory.Destroy(Context);
        }
    }

    [CollectionDefinition("QueryCollection")]
    public class QueryCollection : ICollectionFixture<QueryTestFixture> { }
}
