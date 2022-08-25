using Drugstore.Application.Drugs.Queries.GetDrug;
using Drugstore.Tests.Common;
using Shouldly;

namespace Drugstore.Tests.Drugs.Queries
{
    [Collection("QueryCollection")]
    public class GetDrugQueryHandlerTests
        : TestQueryBase
    {
        public GetDrugQueryHandlerTests(QueryTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GetDrugQueryHAndler_Success()
        {
            var handler = new GetDrugQueryHandler(Context, Mapper);

            var result = await handler.Handle(new GetDrugQuery
            {
                Id = Guid.Parse("0F45976E-DADB-44CE-AA52-F7F188B66D08")
            },
            CancellationToken.None);

            result.ShouldBeOfType<DrugDegtailVm>();
            result.Tittle.ShouldBe("Tittle1");
            result.Description.ShouldBe("descriprion1");
        }
    }
}
