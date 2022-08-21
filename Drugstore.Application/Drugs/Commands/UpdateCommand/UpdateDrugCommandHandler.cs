using Drugstore.Application.Common.Exteptions;
using Drugstore.Application.Interfaces;
using Drugstore.Domain;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Drugstore.Application.Drugs.Commands.UpdateCommand
{
    public class UpdateDrugCommandHandler :
        IRequestHandler<UpdateDrugCommand>
    {
        private readonly IDrugstoreDbContext _dbContext;

        public UpdateDrugCommandHandler(IDrugstoreDbContext context)
        {
            if (_dbContext == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            _dbContext = context;
        }
        public async Task<Unit> Handle(UpdateDrugCommand request, 
            CancellationToken cancellationToken)
        {
            var drug = await _dbContext.Drugs
                .FirstOrDefaultAsync(drug => drug.Id == request.Id, 
                cancellationToken);

            if (drug == null || drug.Id != request.Id)
            {
                throw new NotFoundExteption(nameof(Drug), request.Id);
            }

            drug.Tittle = request.Tittle;
            drug.Quantity = request.Quantity;
            drug.Description = request.Description;
            drug.IsOnPrescription = request.IsOnPrescription;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
