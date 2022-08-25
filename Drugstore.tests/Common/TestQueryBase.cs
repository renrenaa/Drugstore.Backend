using AutoMapper;
using Persistance;

namespace Drugstore.Tests.Common
{
    public class TestQueryBase
    {
        protected readonly DrugstoreDbContext Context;
        protected readonly IMapper Mapper;

        public TestQueryBase(QueryTestFixture fixture)
        {
            Context = fixture.Context;
            Mapper = fixture.Mapper;
        }
    }
}
