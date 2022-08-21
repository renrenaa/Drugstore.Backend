using MediatR;

namespace Drugstore.Application.Drugs.Commands.DeleteDrug
{
    public class DeleteDrugCommand : IRequest
    {
        public Guid Id { get; set; }
    }
}
