using MediatR;

namespace Drugstore.Application.Drugs.Queries.GetDrug
{
    public class GetDrugQuery : IRequest<DrugDegtailVm>
    {
        public Guid Id { get; set; }
    }
}
