using MediatR;

namespace Drugstore.Application.Drugs.Queries.GetDrugList
{
    public class GetDrugListQuery : IRequest<DrugListVm>
    {
    }
}
