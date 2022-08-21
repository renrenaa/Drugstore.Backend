using Drugstore.Application.Common.Exteptions;
using Drugstore.Application.Interfaces;
using Drugstore.Domain;
using MediatR;

namespace Drugstore.Application.Drugs.Commands.DeleteDrug
{
    public class DeleteDrugCommandHandler :
        IRequestHandler<DeleteDrugCommand>
    {
        private readonly IDrugstoreDbContext _dbContext;

        public DeleteDrugCommandHandler(IDrugstoreDbContext context)
        {
            if (_dbContext == null)
            {
                throw new ArgumentNullException(nameof(context));
            }
            _dbContext = context;
        }
        public async Task<Unit> Handle(DeleteDrugCommand request,
            CancellationToken cancellationToken)
        {
            var drug = await _dbContext.Drugs
                .FindAsync(new object[] { request.Id }, cancellationToken);

            if (drug == null || drug.Id != request.Id)
            {
                throw new NotFoundExteption(nameof(Drug), request.Id);
            }

            _dbContext.Drugs.Remove(drug);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }

    }
}

