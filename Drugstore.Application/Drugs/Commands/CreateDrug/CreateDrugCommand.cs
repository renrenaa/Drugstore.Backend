using MediatR;

namespace Drugstore.Application.Drugs.Commands.CreateDrug
{
    public class CreateDrugCommand : IRequest<Guid>
    {
        public Guid Id { get; set; }
        public int Price { get; set; }
        public string Tittle { get; set; }
        public int Quantity { get; set; }
        public string Description { get; set; }
        public bool IsOnPrescription { get; set; }
    }
}
