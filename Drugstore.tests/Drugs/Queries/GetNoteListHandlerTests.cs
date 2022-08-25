using AutoMapper;
using Drugstore.Tests.Common;
using Persistance;
using Drugstore.Application.Drugs.Queries.GetDrugList;
using Shouldly;

namespace Drugstore.Tests.Drugs.Queries
{
    [Collection("QueryCollection")]
    public class GetNoteListHandlerTests
        :TestQueryBase
    {
        public GetNoteListHandlerTests(QueryTestFixture fixture) : base(fixture)
        {
        }

        [Fact]
        public async Task GetNoteListQueryHandler_Success()
        {
            var handler = new GetDrugListQueryHandler(Context, Mapper);
            var count = Context.Drugs.Count();

            var result = await handler.Handle(
                new GetDrugListQuery(), CancellationToken.None);

            result.ShouldBeOfType<DrugListVm>();
            result.Drugs.Count.ShouldBe(count);
        }
    }
}
