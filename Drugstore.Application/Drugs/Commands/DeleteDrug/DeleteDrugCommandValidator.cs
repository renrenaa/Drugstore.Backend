using FluentValidation;

namespace Drugstore.Application.Drugs.Commands.DeleteDrug
{
    public class DeleteDrugCommandValidator 
        : AbstractValidator<DeleteDrugCommand>
    {
        public DeleteDrugCommandValidator()
        {
            RuleFor(deleteDrugCommand =>
                deleteDrugCommand.Id).NotEqual(Guid.Empty);
        }
    }
}
