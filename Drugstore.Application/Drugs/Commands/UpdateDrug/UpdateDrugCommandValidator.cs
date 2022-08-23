using FluentValidation;

namespace Drugstore.Application.Drugs.Commands.UpdateDrug
{
    public class UpdateDrugCommandValidator
        : AbstractValidator<UpdateDrugCommand>
    {
        public UpdateDrugCommandValidator()
        {
            RuleFor(updateDrugCommand =>
                updateDrugCommand.Id).NotEqual(Guid.Empty);
            RuleFor(updateDrugCommand =>
                updateDrugCommand.Price).GreaterThan(0);
            RuleFor(updateDrugCommand =>
                updateDrugCommand.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(updateDrugCommand =>
                updateDrugCommand.Tittle).NotEmpty().MaximumLength(50);
            RuleFor(updateDrugCommand =>
                updateDrugCommand.Tittle).NotEmpty();
        }
    }
}
