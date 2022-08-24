using Drugstore.tests.Common;
using Drugstore.Application.Drugs.Commands.DeleteDrug;
using Microsoft.EntityFrameworkCore;
using Drugstore.Application.Common.Exceptions;

namespace Drugstore.tests.Drugs.Commands
{
    public class DeleteNoteCommandHandlerTests
        :TestCommandBase
    {
        [Fact]
        public async Task DeleteCommandHandler_Success()
        {
            var handler = new DeleteDrugCommandHandler(Context);

            await handler.Handle(new DeleteDrugCommand
            {
                Id = DrugstoreContextFactory.DrugIdForDelete,
            },
            CancellationToken.None);

            Assert.Null(Context.Drugs.SingleOrDefaultAsync(drug =>
                drug.Id == DrugstoreContextFactory.DrugIdForDelete));
        }

        [Fact]
        public async Task DeleteCommandHandler_FailOnWrongId()
        {
            var handler = new DeleteDrugCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundExcepcion>(async () =>
                await handler.Handle(new DeleteDrugCommand
                {
                    Id = Guid.NewGuid()
                }, 
                CancellationToken.None));
        }
    }
}
