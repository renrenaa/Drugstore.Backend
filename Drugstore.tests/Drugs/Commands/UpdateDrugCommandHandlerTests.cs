using Drugstore.Tests.Common;
using Drugstore.Application.Drugs.Commands.UpdateDrug;
using Microsoft.EntityFrameworkCore;
using Drugstore.Application.Common.Exceptions;

namespace Drugstore.Tests.Drugs.Commands
{
    public class UpdateDrugCommandHandlerTests
        : TestCommandBase
    {
        [Fact]
        public async Task UpdateCommandHandler_Succes()
        {
            var handler = new UpdateDrugCommandHandler(Context);
            var price = 107.00m;
            var tittle = "tittleupdated";
            var quantity = 1;
            var description = "descriptionupdated";
            var isOnPrescription = false;

            await handler.Handle(new UpdateDrugCommand
            {
                Id = DrugstoreContextFactory.DrugIdForUpdate,
                Price = price,
                Tittle = tittle,
                Quantity = quantity,
                Description = description,
                IsOnPrescription = isOnPrescription
            },
            CancellationToken.None);

            Assert.NotNull(await Context.Drugs.SingleOrDefaultAsync(drug =>
                drug.Id == DrugstoreContextFactory.DrugIdForUpdate
                && drug.Price == price
                && drug.Tittle == tittle
                && drug.Quantity == quantity
                && drug.Description == description
                && drug.IsOnPrescription == isOnPrescription));
        }

        [Fact]
        public async Task UpdateCommandHandler_FailOnWrongId()
        {
            var handler = new UpdateDrugCommandHandler(Context);

            await Assert.ThrowsAsync<NotFoundExcepcion>(async () =>
                await handler.Handle(
                    new UpdateDrugCommand
                    {
                        Id = Guid.NewGuid()
                    },
                    CancellationToken.None));
        }
    }
}
