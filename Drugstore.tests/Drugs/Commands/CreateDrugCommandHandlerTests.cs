using Drugstore.tests.Common;
using Drugstore.Application.Drugs.Commands.CreateDrug;
using Microsoft.EntityFrameworkCore;

namespace Drugstore.tests.Drugs.Commands
{
    public class CreateDrugCommandHandlerTests
        :TestCommandBase
    {
        [Fact]
        public async Task CreateDrugCommandHandler_Success()
        {
            var handler = new CreateDrugCommandHandler(Context);
            var price = 56.34m;
            var tittle = "tittlecreated";
            var quantity = 3;
            var description = "descriptioncreated";
            var isOnPrescription = false;

            var drugId = await handler.Handle(
                new CreateDrugCommand
                {
                    Id = DrugstoreContextFactory.DrugIdForCreate,
                    Price = price,
                    Tittle = tittle,
                    Quantity = quantity,
                    Description = description,
                    IsOnPrescription = isOnPrescription
                },
                CancellationToken.None); 

            Assert.NotNull(
                await Context.Drugs.SingleOrDefaultAsync(
                    drug => drug.Id == drugId 
                    && drug.Price == price
                    && drug.Tittle == tittle
                    && drug.Quantity == quantity
                    && drug.Description == description
                    && drug.IsOnPrescription == isOnPrescription));
        }
    }
}
