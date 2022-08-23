using FluentValidation;

namespace Drugstore.Application.Drugs.Commands.CreateDrug
{
    public class CreateDrugCommandValidator : 
        AbstractValidator<CreateDrugCommand>
    {
        public CreateDrugCommandValidator()
        {
            RuleFor(createDrugCommand =>
                createDrugCommand.Id).NotEqual(Guid.Empty);
            RuleFor(createDrugCommand =>
                createDrugCommand.Price).GreaterThan(0);
            RuleFor(createDrugCommand =>
                createDrugCommand.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(createDrugCommand =>
                createDrugCommand.Tittle).NotEmpty().MaximumLength(50);
            RuleFor(createDrugCommand => 
                createDrugCommand.Tittle).NotEmpty();
        }
    }
}
