using FluentValidation;

namespace Drugstore.Application.Drugs.Queries.GetDrug
{
    public class GetDrugDetailsValidator 
        : AbstractValidator<DrugDegtailVm>
    {
        public GetDrugDetailsValidator()
        {
            RuleFor(drugDetailVm =>
                drugDetailVm.Id).NotEqual(Guid.Empty);
            RuleFor(drugDetailVm =>
                drugDetailVm.Price).GreaterThan(0);
            RuleFor(drugDetailVm =>
                drugDetailVm.Quantity).GreaterThanOrEqualTo(0);
            RuleFor(drugDetailVm =>
                drugDetailVm.Tittle).NotEmpty().MaximumLength(50);
            RuleFor(drugDetailVm =>
                drugDetailVm.Tittle).NotEmpty();
        }
    }
}
