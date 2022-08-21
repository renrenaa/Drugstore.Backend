using Drugstore.Application.Interfaces;
using Drugstore.Domain;
using MediatR;

namespace Drugstore.Application.Drugs.Commands.CreateDrug
{
    public class CreateDrugCommandHandler : 
        IRequestHandler<CreateDrugCommand, Guid>
    {
        private readonly IDrugstoreDbContext _dbContext;

        public CreateDrugCommandHandler(IDrugstoreDbContext context)
        {
            if(_dbContext == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            _dbContext = context;
        }

        public async Task<Guid> Handle(CreateDrugCommand request, 
            CancellationToken cancellationToken)
        {
            var drug = new Drug
            {
                Id = request.Id,
                Tittle = request.Tittle,
                Quantity = request.Quantity,
                Description = request.Description,
                IsOnPrescription = request.IsOnPrescription
            };

            await _dbContext.Drugs.AddAsync(drug);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return drug.Id;
        }
    }
}
